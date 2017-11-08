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
    public class SupportNombreTicketController : Controller
    {

        //
        // GET: /IndicateurSIHome/
        public ActionResult SupportNombreTicket()
        {

            return View("~/Views/IndicateurSI/IndicateurSISupport/SupportNombreTicket.cshtml");
        }

        public ActionResult StartPage()
        {
            DateTime d = DateTime.Now;
            string dateDebut = "'" + d.AddMonths(-36).ToString("yyyy") + "-00-00 00:00:00'";
            string dateFin = "'" + d.ToString("yyyy") + "-00-00 00:00:00'";

            return reDraw(2, "SAP / Fonctionnel");
        }

        public ActionResult reDraw(int GranulariteID, string SIId)
        {
            DateTime d = DateTime.Now;
            string dateDebut;
            string dateFin;

            switch (GranulariteID)
            {
                case 0:
                    dateDebut = "'" + d.AddMonths(-1).ToString("yyyy-MM-dd") + " 00:00:00'";
                    dateFin = "'" + d.ToString("yyyy-MM-dd") + " 00:00:00'";
                    break;
                case 1:
                    dateDebut = "'" + d.AddMonths(-12).ToString("yyyy-MM-dd") + " 00:00:00'";
                    dateFin = "'" + d.ToString("yyyy-MM-dd") + " 00:00:00'";
                    break;
                case 2:
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

        public ActionResult reDrawAvancee(int GranulariteID, string DateD, string DateF, string SIId)
        {
            string dateDebut = "'" + DateD + " 00:00:00'";
            string dateFin = "'" + DateF + " 00:00:00'";

            return JsonTab(GranulariteID, dateDebut, dateFin, SIId);
        }

        public JsonResult JsonTab(int granularite, string dateDebut, string dateFin, string SIId)
        {
            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd;
            MySqlDataReader reader;

            cmd = connection.CreateCommand();

            string jsonTicketOuvert = "\"ticketOuvert\":[";
            string jsonTicketResolu = "\"ticketResolu\":[";
            string jsonText = "{";

            for (int valBoucle = 0; valBoucle < 2; valBoucle++)
            {
                if (valBoucle == 0) { cmd.CommandText = "SELECT COUNT(*), day(date), week(date), month(date), year(date) FROM glpi_tickets WHERE itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE completename LIKE \"" + SIId + "%\") AND date >= " + dateDebut + " AND date <= " + dateFin + " GROUP BY " + TextGranularite(granularite, valBoucle); }
                else { cmd.CommandText = "SELECT COUNT(*), day(solvedate), week(solvedate), month(solvedate), year(solvedate) FROM glpi_tickets WHERE itilcategories_id IN (SELECT id FROM glpi_itilcategories WHERE completename LIKE \"" + SIId + "%\") AND solvedate >= " + dateDebut + " AND solvedate <= " + dateFin + " GROUP BY " + TextGranularite(granularite, valBoucle); }
                
                connection.Open();
                reader = cmd.ExecuteReader();

                double timestamp;

                int year;
                int month;
                int week = 0;
                int day;
                int nbTickets;

                int i = 0;

                while (reader.Read())
                {
                    if (granularite == 3)
                    {
                        day = 31;
                        month = 12;
                    }
                    else
                    {
                        day = 28;
                        month = 12;
                    }

                    nbTickets = int.Parse(reader.GetString(0)); // - lecture count
                    if (granularite == 0) day = int.Parse(reader.GetString(1)); // - lecture day
                    if (granularite == 1) week = int.Parse(reader.GetString(2)); // - lecture week
                    if (granularite == 0 || granularite == 2) month = int.Parse(reader.GetString(3)); // - lecture month
                    year = int.Parse(reader.GetString(4)); // - lecture year

                    DateTime timestampDate = (new DateTime(year, month, day));
                    if (granularite == 1)
                    {
                        timestampDate = timestampDate.AddDays(week * 7);
                    }
                    timestamp = timestampDate.AddHours(2).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                    string[] timestampSplit = timestamp.ToString().Split('.');

                    if (valBoucle == 0) { jsonTicketOuvert += "[" + timestampSplit[0] + "," + nbTickets + "],"; }
                    else { jsonTicketResolu += "[" + timestampSplit[0] + "," + nbTickets + "],"; }
                    i++;
                }
                connection.Close();

                if (i > 0)
                {
                    if (valBoucle == 0) { jsonTicketOuvert = jsonTicketOuvert.Substring(0, jsonTicketOuvert.Length - 1); }
                    else { jsonTicketResolu = jsonTicketResolu.Substring(0, jsonTicketResolu.Length - 1); }
                }

             }

            jsonTicketOuvert += "]";
            jsonTicketResolu += "]";
            jsonText += jsonTicketOuvert + "," +jsonTicketResolu + "}"; 

            return Json(jsonText);
        }

        public string TextGranularite(int granularite, int valBoucle)
        {
            string text = "year(date)";
            string text2 = "year(solvedate)";
            switch (granularite)
            {
                case 0:
                    if (valBoucle == 0)
                        return text + ", month(date), day(date)";
                    else
                        return text2 + ", month(solvedate), day(solvedate)";
                case 1:
                    if (valBoucle == 0)
                        return text + ", week(date)";
                    else
                        return text2 + ", week(solvedate)";
                case 2:
                    if (valBoucle == 0)
                        return text + ", month(date)";
                    else
                        return text2 + ", month(solvedate)";
                default:
                    if (valBoucle == 0)
                        return text;
                    else
                        return text2;
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
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