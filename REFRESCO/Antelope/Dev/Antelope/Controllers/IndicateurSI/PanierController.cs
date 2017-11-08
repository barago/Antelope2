using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Data.SqlClient;
using MySql.Data.MySqlClient.Properties;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Antelope.Controllers.IndicateurSI
{

    public class PanierController : Controller
    {

        string dateDebut;
        string dateFin;

        // GET: Panier
        public ActionResult Selection()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/PanierSelection.cshtml");
        }

        public ActionResult Print(string data)
        {
            string serverPath = HttpContext.Server.MapPath("~/Executables/");
            Random rnd = new Random();
            

                // TODO - passer l'@ en variable d'environnement

            string[] jsonDecoupe = data.Replace("\"Data\":[", "\"Data\":").Replace("]}", "}").Replace("],[", "]}|{\"Data\":[").Split('|');

            data = data.Replace(" ", "%20").Replace("\"", "%22");
            //string commandParameters = "cd " + serverPath + @" & phantomjs rasterize.js http://localhost:50336/Panier/Rasterize?data=" + data + " " + filename + @" ""A4""";
            for (int i = 0; i < jsonDecoupe.Count(); i++)
            {
                int Id = rnd.Next(100, 999);
                string filename = DateTime.Now.ToString("ddMMyyyy_hhmmss") + Id.ToString();

                MvcHtmlString urlData = new MvcHtmlString(jsonDecoupe[i]);

                string commandParameters = "cd " + serverPath + @" & phantomjs saveImage.js http://localhost:50336/Panier/Rasterize " + urlData + " " + filename;
                //string commandParameters = "cd " + serverPath + @" & phantomjs saveImage.js http://localhost:50336/Panier/Rasterize?data=" + jsonDecoupe[i] + " " + filename;
            
            


                new Thread(new ParameterizedThreadStart(x =>
                {
                    ExecuteCommand(commandParameters);
                })).Start();

                var filePath = Path.Combine(HttpContext.Server.MapPath("~/Executables/"), filename);

                var stream = new MemoryStream();

                byte[] bytes = DoWhile(filePath + ".jpeg");
            }

            return View("~/Views/IndicateurSI/IndicateurSISupport/PanierSelection.cshtml");
        }

            public ActionResult Rasterize()
            {
                ViewBag.Data = ValueProvider.GetValue("data").AttemptedValue;
                return View("~/Views/IndicateurSI/IndicateurSISupport/PanierPrint.cshtml");
            }

            public ActionResult Pdf()
            {
                System.IO.FileStream fs = new FileStream(Server.MapPath("..\\Content\\pdfs") + "\\" + "First PDF document.pdf", FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.AddAuthor("Julien Cokelaere");
                document.AddCreator("Sample application using iTextSharp");
                document.AddKeywords("PDF tutorial education");
                document.AddSubject("Document subject - Describing the steps creating a PDF document");
                document.AddTitle("The document title - PDF creation using iTextSharp");

                document.Open();
                document.Add(new Paragraph("Hello World!"));
                document.Close();
                writer.Close();
                fs.Close();

                return View("~/Views/IndicateurSI/IndicateurSISupport/PanierSelection.cshtml");

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

            private void ExecuteCommand(string Command)
            {
            try
            {
                ProcessStartInfo ProcessInfo;
                Process Process;

                ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;

                Process = Process.Start(ProcessInfo);
            }
            catch { }
        }

        private byte[] DoWhile(string filePath)
        {
            byte[] bytes = new byte[0];
            bool fail = true;

            while (fail)
            {
                try
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        bytes = new byte[file.Length];
                        file.Read(bytes, 0, (int)file.Length);
                    }

                    fail = false;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

            //System.IO.File.Delete(filePath);
            return bytes;
        }
    }
}