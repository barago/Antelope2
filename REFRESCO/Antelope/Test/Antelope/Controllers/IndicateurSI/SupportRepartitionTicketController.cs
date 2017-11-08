using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient.Properties;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Antelope.Controllers.IndicateurSI
{
    public class SupportRepartitionTicketController : Controller
    {
        string dateDebut;
        string dateFin;
        //
        // GET: /SupportRepartitionTicket/
        public ActionResult SupportRepartitionTicket()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/SupportRepartitionTicket.cshtml");
        }

        public ActionResult reDraw(int dateId, string SIId)
        {
            DateTime d = DateTime.Now;
            string dateDeb = d.AddMonths(-dateId).ToString("yyyy-MM");
            dateDebut = "'" + dateDeb + "-00 00:00:00'";
            string dateF = d.AddMonths(-(dateId - 1)).ToString("yyyy-MM");
            dateFin = "'" + dateF + "-00 00:00:00'";

            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd;
            MySqlDataReader reader;

            List<string> name = new List<string>();

            cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT name FROM glpi_itilcategories WHERE completename LIKE '" + SIId + " >%'";
            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            connection.Close();

            string jsonText = "{\"Resultat\":[";
            int somme = 0;

            for (int i = 0; i < name.Count; i++)
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM glpi_tickets WHERE date >= " + dateDebut + " AND date <= " + dateFin + " AND itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE name = '" + name[i] + "')";
                connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jsonText += "[\"" + name[i] + "\"," + int.Parse(reader.GetString(0)) + "],";
                    somme += int.Parse(reader.GetString(0));
                }
                
                
                connection.Close();
            }
            jsonText = jsonText.Substring(0, jsonText.Length - 1);
            jsonText += "],\"Date\":" + dateId + ",\"TotalTickets\":" + somme + "}";
            return Json(jsonText);
        }


        public ActionResult tabLien(int dateId, string nameCat)
        {
            DateTime d = DateTime.Now;
            string dateDeb = d.AddMonths(-dateId).ToString("yyyy-MM");
            dateDebut = "'" + dateDeb + "-00 00:00:00'";
            string dateF = d.AddMonths(-(dateId - 1)).ToString("yyyy-MM");
            dateFin = "'" + dateF + "-00 00:00:00'";

            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd;
            MySqlDataReader reader;
            string jsonText = "{\"Prio\":[";
            string jsonID = "";
            string jsonName = "";
            string jsonType = "";
            string jsonSatisfaction = "";
            string jsonStatut = "";
            string jsonDateOpen = "";
            string jsonDateModif = "";
            string jsonVal = "";
            string jsonDemandeur = "";
            string jsonTechnicien = "";

            for (int i = 1; i < 6; i++)
            {
                cmd = connection.CreateCommand();
                /* A REGARDER -- Pb avec type = 2 */
                cmd.CommandText = "SELECT glpi_tickets.id, glpi_tickets.name, glpi_tickets.type, satisfaction, glpi_tickets.status, glpi_tickets.date, glpi_tickets.date_mod, glpi_users.firstname, glpi_users.realname, Gu.firstname, Gu.realname FROM glpi_tickets LEFT JOIN glpi_ticketsatisfactions on glpi_tickets.id = glpi_ticketsatisfactions.tickets_id LEFT JOIN glpi_users on glpi_tickets.users_id_recipient = glpi_users.id LEFT JOIN glpi_tickets_users on glpi_tickets.id = glpi_tickets_users.tickets_id LEFT JOIN glpi_users as Gu on glpi_tickets_users.users_id = Gu.id  WHERE date >= " + dateDebut + " AND date <= " + dateFin + " AND priority =" + i + " AND itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE name ='" + nameCat + "') AND glpi_tickets_users.type = 2 GROUP BY glpi_tickets.id";
                /* A REGARDER -- Pb avec type = 2 */
                connection.Open();

                reader = cmd.ExecuteReader();
                int j = 0;
                jsonID = "{\"ID\":[";
                jsonName = "\"Name\":[";
                jsonType = "\"Type\":[";
                jsonSatisfaction = "\"Satisfaction\":[";
                jsonStatut = "\"Statut\":[";
                jsonDateOpen = "\"DateOpen\":[";
                jsonDateModif = "\"DateModif\":[";
                jsonDemandeur = "\"Demandeur\":[";
                jsonTechnicien = "\"Technicien\":[";

                while (reader.Read())
                    {
                        jsonID += int.Parse(reader.GetString(0)) + ",";
                        jsonName += "\"" + (reader.GetString(1).Replace("\\","\\\\").Replace("\"","\\\"")) + "\",";
                        jsonType += "\"" + int.Parse(reader.GetString(2)) + "\",";
                        if (reader.GetValue(3).ToString() != "") { jsonSatisfaction += "\"" + int.Parse(reader.GetString(3)) + "\","; }
                        else { jsonSatisfaction += "\"0\","; }
                        jsonStatut += "\"" + int.Parse(reader.GetString(4)) + "\",";
                        jsonDateOpen += "\"" + reader.GetString(5) + "\",";
                        jsonDateModif += "\"" + reader.GetString(6) + "\",";
                        if (reader.GetValue(7).ToString() != "") { jsonDemandeur += "\"" + reader.GetString(7) + "<br/>"; } else { jsonDemandeur += "\""; }
                        if (reader.GetValue(8).ToString() != "") { jsonDemandeur += reader.GetString(8) + "\","; } else { jsonDemandeur += "\","; }
                        if (reader.GetValue(9).ToString() != "") { jsonTechnicien += "\"" + reader.GetString(9) + "<br/>"; } else { jsonTechnicien += "\""; }
                        if (reader.GetValue(10).ToString() != "") { jsonTechnicien += reader.GetString(10) + "\","; } else { jsonTechnicien += "\","; }
                        j++; 
                    }
                if (j > 0)
                {
                    jsonID = jsonID.Substring(0, jsonID.Length - 1);
                    jsonName = jsonName.Substring(0, jsonName.Length - 1);
                    jsonType = jsonType.Substring(0, jsonType.Length - 1);
                    jsonSatisfaction = jsonSatisfaction.Substring(0, jsonSatisfaction.Length - 1);
                    jsonStatut = jsonStatut.Substring(0, jsonStatut.Length - 1);
                    jsonDateOpen = jsonDateOpen.Substring(0, jsonDateOpen.Length - 1);
                    jsonDateModif = jsonDateModif.Substring(0, jsonDateModif.Length - 1);
                    jsonDemandeur = jsonDemandeur.Substring(0, jsonDemandeur.Length - 1);
                    jsonTechnicien = jsonTechnicien.Substring(0, jsonTechnicien.Length - 1);
                }
                connection.Close();
                jsonID += "]";
                jsonName += "]";
                jsonType += "]";
                jsonSatisfaction += "]";
                jsonStatut += "]";
                jsonDateOpen += "]";
                jsonDateModif += "]";
                jsonDemandeur += "]";
                jsonTechnicien += "]";
                jsonVal = "\"Val\":" + j;
                jsonText += jsonID + "," + jsonName + "," + jsonType + "," + jsonStatut + "," + jsonDateOpen + "," + jsonDateModif + "," + jsonDemandeur + "," + jsonTechnicien + "," + jsonSatisfaction + "," + jsonVal + "},";
            }
            jsonText = jsonText.Substring(0, jsonText.Length - 1);
            jsonText += "]}";
                return Json(jsonText);
            

        }

        public ActionResult recupNameSI()
        {
            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT name FROM glpi_itilcategories WHERE level = 1";
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            string jsonText = "{\"name\":[";

            while (reader.Read())
            {
                if (reader.GetString(0) != "Master Data") jsonText += "\"" + reader.GetString(0) + "\",";
            }
            jsonText = jsonText.Substring(0, jsonText.Length - 1);
            jsonText += "]}";
                return Json(jsonText);
        }
    }
}