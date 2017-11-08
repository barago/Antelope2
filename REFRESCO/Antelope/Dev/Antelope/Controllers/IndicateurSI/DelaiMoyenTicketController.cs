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
    public class DelaiMoyenTicketController : Controller
    {
        //
        // GET: /DelaiMoyenTicket/
        public ActionResult DelaiMoyenTicket()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/DelaiMoyenTicket.cshtml");
        }

        public ActionResult StartPage()
        {
            DateTime d = DateTime.Now;
            string dateDebut = "'" + d.AddMonths(-36).ToString("yyyy") + "-00-00 00:00:00'";
            string dateFin = "'" + d.ToString("yyyy") + "-00-00 00:00:00'";

            return Draw(0, "SAP / Fonctionnel");
        }

        public ActionResult Draw(int GranulariteID, string SIId)
        {
            DateTime d = DateTime.Now;
            string dateDebut;
            string dateFin;

            switch (GranulariteID)
            {
                case 0:
                    dateDebut = "'" + d.AddMonths(-36).ToString("yyyy-MM") + "-00 00:00:00'";
                    dateFin = "'" + d.ToString("yyyy-MM") + "-00 00:00:00'";
                    break;
                default:
                    dateDebut = "'2008-00-00 00:00:00'";
                    dateFin = "'" + d.AddMonths(-d.Month).ToString("yyyy-MM") + "-00 00:00:00'";
                    break;
            }

            return JsonTab(GranulariteID, dateDebut, dateFin, SIId);
        }

        public JsonResult JsonTab(int granularite, string dateDebut, string dateFin, string SIId)
        {
            double timestamp;

            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd;
            MySqlDataReader reader;

            cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT type, AVG(DATEDIFF(solvedate, date)), day(date), week(date), month(date), year(date), count(*) FROM glpi_tickets WHERE itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE completename LIKE \"" + SIId + "%\") AND date >= " + dateDebut + " AND date <= " + dateFin + " GROUP BY " + TextGranularite(granularite) + ", type";
            connection.Open();
            reader = cmd.ExecuteReader();

            int year;
            int month;
            int day;
            string moyenne;

            string moyenneTempsTicketDemande = "\"tempsDemande\":[";
            string moyenneTempsTicketIncident = "\"tempsIncident\":[";
            string jsonText = "{";

            while (reader.Read())
            {
                if (granularite == 1)
                {
                    day = 31;
                    month = 12;
                }
                else
                {
                    day = 28;
                    month = 12;
                }

                int type = int.Parse(reader.GetString(0)); // - lecture type
                if (reader.GetValue(1).ToString() != "") { moyenne = reader.GetString(1); } else { moyenne = "null"; } // - lecture moyenne
                if (granularite == 0) month = int.Parse(reader.GetString(4)); // - lecture month
                year = int.Parse(reader.GetString(5)); // - lecture year

                DateTime timestampDate = (new DateTime(year, month, day));
                timestamp = timestampDate.AddHours(2).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                string[] timestampSplit = timestamp.ToString().Split('.');

                if (type == 1) { moyenneTempsTicketIncident += "[" + timestampSplit[0] + "," + moyenne.Replace(',','.') + "],"; }
                else { moyenneTempsTicketDemande += "[" + timestampSplit[0] + "," + moyenne.Replace(',', '.') + "],"; }
            }

            connection.Close();
            if (moyenneTempsTicketIncident != "\"tempsIncident\":[") { moyenneTempsTicketIncident = moyenneTempsTicketIncident.Substring(0, moyenneTempsTicketIncident.Length - 1); }
            if (moyenneTempsTicketDemande != "\"tempsDemande\":[") { moyenneTempsTicketDemande = moyenneTempsTicketDemande.Substring(0, moyenneTempsTicketDemande.Length - 1); }
            moyenneTempsTicketIncident += "]";
            moyenneTempsTicketDemande += "]";

            jsonText += moyenneTempsTicketIncident + "," + moyenneTempsTicketDemande + "}";

            return Json(jsonText);
        }

        public string TextGranularite(int granularite)
        {
            string text = "year(date)";
            switch (granularite)
            {
                case 0:
                    return text + ", month(date)";
                default:
                    return text;
            }
        }

        public string TextGranularite(int granularite, int valBoucle)
        {
            string text = "year(date)";
            switch (granularite)
            {
                case 0:
                        return text + ", month(date)";
                default:
                        return text;
            }
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