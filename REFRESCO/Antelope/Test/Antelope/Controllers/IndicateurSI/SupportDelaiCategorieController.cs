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
    public class SupportDelaiCategorieController : Controller
    {
        string dateDebut;
        string dateFin;
        //
        // GET: /SupportDelaiCategorie/
        public ActionResult SupportDelaiCategorie()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/SupportDelaiCategorie.cshtml");
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

            string jsonCat = "\"Categorie\":[";

            string jsonValResolution = "\"ValSolve\":[";
            string jsonValResolutionIncident = "\"ValSolveIncident\":[";
            string jsonValResolutionDemande = "\"ValSolveDemande\":[";

            //string jsonValPriseCompte = "[";

            float total = 0;
            float totalIncident = 0;
            float totalDemande = 0;

            float k = 0;
            float kIncident = 0;
            float kDemande = 0;

            for (int i = 0; i < name.Count; i++)
            {
                jsonCat += "\"" + name[i] + "\",";
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT date,solvedate,type FROM glpi_tickets WHERE date >= " + dateDebut + " AND date <= " + dateFin + " AND itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE name = '" + name[i] + "')";
                connection.Open();
                reader = cmd.ExecuteReader();

                int j = 0;
                int jIncident = 0;
                int jDemande = 0;

                float moyenne = 0;
                float moyenneIncident = 0;
                float moyenneDemande = 0;

                while (reader.Read())
                {
                    if (reader.GetValue(1).ToString() != "")
                    {
                        string[] DateAndHour = reader.GetString(0).Split(' ');
                        string[] Date = DateAndHour[0].Split('/');
                        string[] SolveDateAndHour = reader.GetString(1).Split(' ');
                        string[] SolveDate = SolveDateAndHour[0].Split('/');
                        DateTime date1 = new DateTime(int.Parse(Date[2]), int.Parse(Date[1]), int.Parse(Date[0]));
                        DateTime date2 = new DateTime(int.Parse(SolveDate[2]), int.Parse(SolveDate[1]), int.Parse(SolveDate[0]));
                        moyenne += ((TimeSpan)(date2 - date1)).Days;
                        j++;
                        if (int.Parse(reader.GetString(2)) == 1) 
                        {
                            moyenneIncident += ((TimeSpan)(date2 - date1)).Days;
                            jIncident++;
                        }
                        else
                        {
                            moyenneDemande += ((TimeSpan)(date2 - date1)).Days;
                            jDemande++;
                        }
                        
                    }
                }
                if (j == 0)
                    moyenne = 0;
                else
                    moyenne /= j;
                jsonValResolution += moyenne.ToString().Replace(',', '.') + ",";

                if (jIncident == 0)
                    moyenneIncident = 0;
                else
                    moyenneIncident /= jIncident;
                jsonValResolutionIncident += moyenneIncident.ToString().Replace(',', '.') + ",";

                if (jDemande == 0)
                    moyenneDemande = 0;
                else
                    moyenneDemande /= jDemande;
                jsonValResolutionDemande += moyenneDemande.ToString().Replace(',', '.') + ",";

                connection.Close();

                if (moyenne != 0)
                {
                    total += moyenne;
                    k++;
                }

                if (moyenneIncident != 0)
                {
                    totalIncident += moyenneIncident;
                    kIncident++;
                }

                if (moyenneDemande != 0)
                {
                    totalDemande += moyenneDemande;
                    kDemande++;
                }
            }
            jsonCat += "\"Total\"]";
            jsonValResolution += (total / k).ToString().Replace(',','.') + "]";
            jsonValResolutionIncident += (totalIncident / kIncident).ToString().Replace(',', '.') + "]";
            jsonValResolutionDemande += (totalDemande / kDemande).ToString().Replace(',', '.') + "]";
            return Json("{" + jsonCat + "," + jsonValResolution + "," + jsonValResolutionIncident + "," + jsonValResolutionDemande + ",\"Date\":" + dateId + "}");
        }

        public ActionResult reDrawCategorie(int dateId, string categorie)
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

            string jsonCat = "\"Categorie\":[\"Priorité trés haute\",\"Priorité haute\",\"Priorité moyenne\",\"Priorité basse\",\"Priorité trés basse\"]";

            string jsonValResolution = "\"ValSolve\":[";
            string jsonValResolutionIncident = "\"ValSolveIncident\":[";
            string jsonValResolutionDemande = "\"ValSolveDemande\":[";

            //string jsonValPriseCompte = "[";

            for (int i = 5; i > 0; i--)
            {
                cmd = connection.CreateCommand();
                if (categorie != "Total"){
                    cmd.CommandText = "SELECT date,solvedate,type FROM glpi_tickets WHERE priority = "+ i + " AND date >= " + dateDebut + " AND date <= " + dateFin + " AND itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE name = '" + categorie + "')";
                }
                else { 
                    cmd.CommandText = "SELECT date,solvedate,type FROM glpi_tickets WHERE priority = " + i + " AND date >= " + dateDebut + " AND date <= " + dateFin;
                }
                connection.Open();
                reader = cmd.ExecuteReader();

                int j = 0;
                int jIncident = 0;
                int jDemande = 0;

                float moyenne = 0;
                float moyenneIncident = 0;
                float moyenneDemande = 0;

                while (reader.Read())
                {
                    if (reader.GetValue(1).ToString() != "")
                    {
                        string[] DateAndHour = reader.GetString(0).Split(' ');
                        string[] Date = DateAndHour[0].Split('/');
                        string[] SolveDateAndHour = reader.GetString(1).Split(' ');
                        string[] SolveDate = SolveDateAndHour[0].Split('/');
                        DateTime date1 = new DateTime(int.Parse(Date[2]), int.Parse(Date[1]), int.Parse(Date[0]));
                        DateTime date2 = new DateTime(int.Parse(SolveDate[2]), int.Parse(SolveDate[1]), int.Parse(SolveDate[0]));
                        moyenne += ((TimeSpan)(date2 - date1)).Days;
                        j++;
                        if (int.Parse(reader.GetString(2)) == 1)
                        {
                            moyenneIncident += ((TimeSpan)(date2 - date1)).Days;
                            jIncident++;
                        }
                        else
                        {
                            moyenneDemande += ((TimeSpan)(date2 - date1)).Days;
                            jDemande++;
                        }

                    }
                }
                if (j == 0)
                    moyenne = 0;
                else
                    moyenne /= j;
                jsonValResolution += moyenne.ToString().Replace(',', '.') + ",";

                if (jIncident == 0)
                    moyenneIncident = 0;
                else
                    moyenneIncident /= jIncident;
                jsonValResolutionIncident += moyenneIncident.ToString().Replace(',', '.') + ",";

                if (jDemande == 0)
                    moyenneDemande = 0;
                else
                    moyenneDemande /= jDemande;
                jsonValResolutionDemande += moyenneDemande.ToString().Replace(',', '.') + ",";

                connection.Close();
            }
            jsonValResolution = jsonValResolution.Substring(0, jsonValResolution.Length - 1);
            jsonValResolutionIncident = jsonValResolutionIncident.Substring(0, jsonValResolutionIncident.Length - 1);
            jsonValResolutionDemande = jsonValResolutionDemande.Substring(0, jsonValResolutionDemande.Length - 1);

            jsonValResolution += "]";
            jsonValResolutionIncident += "]";
            jsonValResolutionDemande += "]";
            return Json("{" + jsonCat + "," + jsonValResolution + "," + jsonValResolutionIncident + "," + jsonValResolutionDemande + ",\"Date\":" + dateId + "}");
        }
    }
}