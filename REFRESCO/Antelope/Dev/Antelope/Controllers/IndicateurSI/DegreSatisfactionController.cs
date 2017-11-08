using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;
using MySql.Data.MySqlClient.Properties;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;

namespace Antelope.Controllers.IndicateurSI
{
    public class DegreSatisfactionController : Controller
    {
        //
        // GET: /DegreSatisfaction/
        public ActionResult DegreSatisfaction()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/DegreSatisfaction.cshtml");
        }

        public ActionResult StartPage()
        {
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
            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd;
            MySqlDataReader reader;

            cmd = connection.CreateCommand();

            string jsonText = "{\"Resultat\":[";

                cmd.CommandText = "SELECT avg(satisfaction), month(date), year(date) FROM glpi_tickets LEFT JOIN glpi_itilcategories as ic on glpi_tickets.itilcategories_id = ic.id LEFT JOIN glpi_ticketsatisfactions as ts on glpi_tickets.id = ts.tickets_id WHERE ic.completename LIKE '" + SIId + "%' AND date >= " + dateDebut + " AND date <= " + dateFin + " GROUP BY " + TextGranularite(granularite);

                connection.Open();
                reader = cmd.ExecuteReader();

                double timestamp;

                int day;
                int year;
                int month = 0;
                string satisfaction = "null";

                int i = 0;

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
                    }

                    if (reader.GetValue(0).ToString() != "") satisfaction = reader.GetString(0); // - lecture satisfaction
                    if (granularite == 0) month = int.Parse(reader.GetString(1)); // - lecture month
                    year = int.Parse(reader.GetString(2)); // - lecture year

                    DateTime timestampDate = (new DateTime(year, month, day));
                    timestamp = timestampDate.AddHours(2).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                    string[] timestampSplit = timestamp.ToString().Split('.');

                    jsonText += "[" + timestampSplit[0] + "," + satisfaction.Replace(',','.') + "],";
                    i++;
                }
                connection.Close();

                if (i > 0)
                {
                    jsonText = jsonText.Substring(0, jsonText.Length - 1);
                }

                jsonText += "]}";

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

        public ActionResult recupNameSI()
        {
            string ConnexionString = ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;
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