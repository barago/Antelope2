using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient.Properties;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Antelope.Domain.Models;
using PagedList;
using System.Net.Mail;
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.IndicateurSI
{
    // Pour ajouter des intervenants, vue (Intervention.cshtml) ligne 63

    public class InterventionController : Controller
    {
        private AntelopeEntities db = new AntelopeEntities();
        // GET: Intervention
        public ActionResult Intervention()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/Intervention.cshtml");
        }

        public int AddIntervention(string intervenant, string dateIntervention, Boolean planifie, Boolean ferie, string demandeur, string motif, int dureeIntervention, Boolean noteFrais)
        {
            string[] dateSplit = dateIntervention.Split(' ');
            string[] dateElements = dateSplit[0].Split('-');
            string[] hourElements = dateSplit[1].Split(':');
            DateTime dateInter = new DateTime(int.Parse(dateElements[2]), int.Parse(dateElements[1]), int.Parse(dateElements[0]), int.Parse(hourElements[0]), int.Parse(hourElements[1]), 0);
            int jourSemaine = (int)dateInter.DayOfWeek;
            if (jourSemaine == 0) { jourSemaine = 7; }

            // Jours de la semaine => Lundi: 1, Mardi: 2, Mercredi: 3, Jeudi: 4, Vendredi: 5, Samedi: 6, Dimanche: 7 

            int primeInter = 0;
            int primeDimancheEtJourFerie = 0;
            
            if (!planifie && jourSemaine < 5) { primeInter = 35; }
            if (!planifie && jourSemaine > 4) { primeInter = 50; }

            if (jourSemaine == 7 || ferie) { primeDimancheEtJourFerie = 38; }
            
            Intervention NouvelleIntervention = new Intervention()
            {

                Intervenant = intervenant,
                DateIntervention = dateIntervention,
                Planifie = planifie,
                Demandeur = demandeur,
                Motif = motif,
                DureeIntervention = dureeIntervention,
                NoteFrais = noteFrais,
                PrimeIntervention = primeInter,
                PrimeDimanche = primeDimancheEtJourFerie,
                Valide = false
            };

            db.Interventions.Add(NouvelleIntervention);
            db.SaveChanges();

            return 0;
        }

        public int EditIntervention(int ID, string intervenant, string dateIntervention, Boolean planifie, Boolean ferie, string demandeur, string motif, int dureeIntervention, Boolean noteFrais)
        {
            string[] dateSplit = dateIntervention.Split(' ');
            string[] dateElements = dateSplit[0].Split('-');
            string[] hourElements = dateSplit[1].Split(':');
            DateTime dateInter = new DateTime(int.Parse(dateElements[2]), int.Parse(dateElements[1]), int.Parse(dateElements[0]), int.Parse(hourElements[0]), int.Parse(hourElements[1]), 0);
            int jourSemaine = (int)dateInter.DayOfWeek;
            if (jourSemaine == 0) { jourSemaine = 7; }

            // Jours de la semaine => Lundi: 1, Mardi: 2, Mercredi: 3, Jeudi: 4, Vendredi: 5, Samedi: 6, Dimanche: 7 

            int primeInter = 0;
            int primeDimancheEtJourFerie = 0;

            if (!planifie && jourSemaine < 5) { primeInter = 35; }
            if (!planifie && jourSemaine > 4) { primeInter = 50; }

            if (jourSemaine == 7 || ferie) { primeDimancheEtJourFerie = 38; }

            var interventions = from i in db.Interventions
                                where i.InterventionID == ID
                                select i;

            foreach (var elem in interventions)
            {
                elem.Intervenant = intervenant;
                elem.DateIntervention = dateIntervention;
                elem.Planifie = planifie;
                elem.Demandeur = demandeur;
                elem.Motif = motif;
                elem.DureeIntervention = dureeIntervention;
                elem.NoteFrais = noteFrais;
                elem.PrimeIntervention = primeInter;
                elem.PrimeDimanche = primeDimancheEtJourFerie;
                elem.Valide = false;
            }

            db.SaveChanges();

            return 0;
        }

        public ActionResult Draw (int granularite)
        {
            string jsonDeplacement = "\"Deplacement\":[";
            string jsonTotal = "\"Total\":[";
            double timestamp;

            if (granularite == 1)
            {

                for (int j = 2013; j <= DateTime.Now.Year; j++)
                {
                    string date = j.ToString();
                    var InterventionsAnnee =    from i in db.Interventions
                                                where i.DateIntervention.Contains(date)
                                                select i;

                    List<Intervention> listeIntervention = InterventionsAnnee.ToList();

                    DateTime timestampDate;
                    if (j != DateTime.Now.Year)
                    {
                        timestampDate = (new DateTime(j, 12, 31));
                    }
                    else
                    {
                        timestampDate = (new DateTime(j, DateTime.Now.Month, DateTime.Now.Day));
                    }
                    
                    timestamp = timestampDate.AddHours(2).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                    string[] timestampSplit = timestamp.ToString().Split('.');

                    int countInterventionsAnneeDeplacement = 0;
                    int countInterventionsAnneeDistance = 0;

                    for (int i = 0; i < listeIntervention.Count; i++)
                    {
                        if (listeIntervention[i].NoteFrais)
                        {
                            countInterventionsAnneeDeplacement++;
                        }
                        else
                        {
                            countInterventionsAnneeDistance++;
                        }
                    }

                        jsonDeplacement += "[" + timestampSplit[0] + "," + countInterventionsAnneeDeplacement + "],";
                        jsonTotal += "[" + timestampSplit[0] + "," + (countInterventionsAnneeDistance + countInterventionsAnneeDeplacement) + "],";
                         
                }

                jsonDeplacement = jsonDeplacement.Substring(0, jsonDeplacement.Length - 1);
                jsonTotal = jsonTotal.Substring(0, jsonTotal.Length - 1);
                jsonDeplacement += "]";
                jsonTotal += "]";
            }
            else
            {
                for (int a = DateTime.Now.AddMonths(-36).Year; a <= DateTime.Now.Year; a++)
                {
                    int mMax = 12;
                    int mMin = 1;

                    if (a == DateTime.Now.Year)
                    {
                        mMax = DateTime.Now.Month;
                    }
                    if (a == DateTime.Now.AddMonths(-36).Year)
                    {
                        mMin = DateTime.Now.Month;
                    }

                    for (int m = mMin; m <= mMax; m++)
                        {
                            string date = "";
                            if (m < 10) { date += "0" + m; } else { date += m; }
                            date += "-" + a.ToString();
                            var InterventionsAnnee = from i in db.Interventions
                                                     where i.DateIntervention.Contains(date)
                                                     select i;

                            List<Intervention> listeIntervention = InterventionsAnnee.ToList();

                            DateTime timestampDate = (new DateTime(a, m, DateTime.DaysInMonth(a, m)));
                            timestamp = timestampDate.AddHours(2).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                            string[] timestampSplit = timestamp.ToString().Split('.');

                            int countInterventionsAnneeDeplacement = 0;
                            int countInterventionsAnneeDistance = 0;

                            for (int i = 0; i < listeIntervention.Count; i++)
                            {
                                if (listeIntervention[i].NoteFrais)
                                {
                                    countInterventionsAnneeDeplacement++;
                                }
                                else
                                {
                                    countInterventionsAnneeDistance++;
                                }
                            }

                                jsonDeplacement += "[" + timestampSplit[0] + "," + countInterventionsAnneeDeplacement + "],";
                                jsonTotal += "[" + timestampSplit[0] + "," + (countInterventionsAnneeDistance + countInterventionsAnneeDeplacement) + "],";
                         
                        }

                    }

                    jsonDeplacement = jsonDeplacement.Substring(0, jsonDeplacement.Length - 1);
                    jsonTotal = jsonTotal.Substring(0, jsonTotal.Length - 1);
                    jsonDeplacement += "]";
                    jsonTotal += "]";
                }

            string jsonText = "{" + jsonDeplacement + "," + jsonTotal + "}";
            return Json(jsonText);
        }

        public ActionResult AfficherNonValide()
        {
            var interventionsNonValides =   from i in db.Interventions
                                            where i.Valide == false
                                            select i;

            interventionsNonValides = interventionsNonValides.OrderBy(i => i.InterventionID);

            List<Intervention> listeIntervention = interventionsNonValides.ToList();

            string jsonID = "\"ID\":[";
            string jsonIntervenant = "\"Intervenant\":[";
            string jsonDateIntervention = "\"DateIntervention\":[";
            string jsonPlanifie = "\"Planifie\":[";
            string jsonDemandeur = "\"Demandeur\":[";
            string jsonMotif = "\"Motif\":[";
            string jsonDureeIntervention = "\"DureeIntervention\":[";
            string jsonNoteFrais = "\"NoteFrais\":[";
            string jsonPrimeIntervention = "\"PrimeIntervention\":[";
            string jsonPrimeDimanche = "\"PrimeDimanche\":[";
            string jsonValide = "\"Valide\":[";

            int k = 0;

            for (k = 0; k < listeIntervention.Count; k++)
            {
                jsonID += "\"" + listeIntervention[k].InterventionID + "\",";
                jsonIntervenant += "\"" + listeIntervention[k].Intervenant + "\",";
                jsonDateIntervention += "\"" + listeIntervention[k].DateIntervention + "\",";
                if (listeIntervention[k].Planifie == true)
                    jsonPlanifie += "true,";
                else
                    jsonPlanifie += "false,";
                jsonDemandeur += "\"" + listeIntervention[k].Demandeur + "\",";
                jsonMotif += "\"" + listeIntervention[k].Motif + "\",";
                jsonDureeIntervention += listeIntervention[k].DureeIntervention + ",";
                if (listeIntervention[k].NoteFrais == true)
                    jsonNoteFrais += "true,";
                else
                    jsonNoteFrais += "false,";
                jsonPrimeIntervention += listeIntervention[k].PrimeIntervention + ",";
                jsonPrimeDimanche += listeIntervention[k].PrimeDimanche + ",";
                if (listeIntervention[k].Valide == true)
                    jsonValide += "true,";
                else
                    jsonValide += "false,";
            }

            if (k > 0)
            {
                jsonID = jsonID.Substring(0, jsonID.Length - 1);
                jsonIntervenant = jsonIntervenant.Substring(0, jsonIntervenant.Length - 1);
                jsonDateIntervention = jsonDateIntervention.Substring(0, jsonDateIntervention.Length - 1);
                jsonPlanifie = jsonPlanifie.Substring(0, jsonPlanifie.Length - 1);
                jsonDemandeur = jsonDemandeur.Substring(0, jsonDemandeur.Length - 1);
                jsonMotif = jsonMotif.Substring(0, jsonMotif.Length - 1);
                jsonDureeIntervention = jsonDureeIntervention.Substring(0, jsonDureeIntervention.Length - 1);
                jsonNoteFrais = jsonNoteFrais.Substring(0, jsonNoteFrais.Length - 1);
                jsonPrimeIntervention = jsonPrimeIntervention.Substring(0, jsonPrimeIntervention.Length - 1);
                jsonPrimeDimanche = jsonPrimeDimanche.Substring(0, jsonPrimeDimanche.Length - 1);
                jsonValide = jsonValide.Substring(0, jsonValide.Length - 1);
            }

            jsonID += "]";
            jsonIntervenant += "]";
            jsonDateIntervention += "]";
            jsonPlanifie += "]";
            jsonDemandeur += "]";
            jsonMotif += "]";
            jsonDureeIntervention += "]";
            jsonNoteFrais += "]";
            jsonPrimeIntervention += "]";
            jsonPrimeDimanche += "]";
            jsonValide += "]";

            string jsonText = "{" + jsonID + "," + jsonIntervenant + "," + jsonDateIntervention + "," + jsonPlanifie + "," + jsonDemandeur + "," + jsonMotif + "," + jsonDureeIntervention + "," + jsonNoteFrais + "," + jsonPrimeIntervention + "," + jsonPrimeDimanche + "," + jsonValide + "}";

            return Json(jsonText);
        }

        public ActionResult MAJTabIntervention(string date)
        {

            // granularite 0: mois -> date format: "MM-AAAA"
            // granularite 1: annee -> date format: "AAAA"

            var splitDate = date.Split('-');
            string jsongranularite = "\"Granularite\":";

            if (splitDate.Length == 2)
            {
                jsongranularite += "0";
            }
            else
            {
                jsongranularite += "1";
            }

            var interventions = from i in db.Interventions
                                where i.DateIntervention.Contains(date)
                                select i;

            interventions = interventions.OrderBy(i => i.InterventionID);

            List<Intervention> listeIntervention = interventions.ToList();

            string jsonID = "\"ID\":[";
            string jsonIntervenant = "\"Intervenant\":[";
            string jsonDateIntervention = "\"DateIntervention\":[";
            string jsonPlanifie = "\"Planifie\":[";
            string jsonDemandeur = "\"Demandeur\":[";
            string jsonMotif = "\"Motif\":[";
            string jsonDureeIntervention = "\"DureeIntervention\":[";
            string jsonNoteFrais = "\"NoteFrais\":[";
            string jsonPrimeIntervention = "\"PrimeIntervention\":[";
            string jsonPrimeDimanche = "\"PrimeDimanche\":[";
            string jsonValide = "\"Valide\":[";

            int k = 0;

            for (k = 0; k < listeIntervention.Count; k++)
            {
                jsonID += "\"" + listeIntervention[k].InterventionID + "\",";
                jsonIntervenant += "\"" + listeIntervention[k].Intervenant + "\",";
                jsonDateIntervention += "\"" + listeIntervention[k].DateIntervention + "\",";
                if (listeIntervention[k].Planifie == true)
                    jsonPlanifie += "true,";
                else
                    jsonPlanifie += "false,";
                jsonDemandeur += "\"" + listeIntervention[k].Demandeur + "\",";
                jsonMotif += "\"" + listeIntervention[k].Motif + "\",";
                jsonDureeIntervention += listeIntervention[k].DureeIntervention + ",";
                if (listeIntervention[k].NoteFrais == true)
                    jsonNoteFrais += "true,";
                else
                    jsonNoteFrais += "false,";
                jsonPrimeIntervention += listeIntervention[k].PrimeIntervention + ",";
                jsonPrimeDimanche += listeIntervention[k].PrimeDimanche + ",";
                if (listeIntervention[k].Valide == true)
                    jsonValide += "true,";
                else
                    jsonValide += "false,";
            }

            if (k > 0)
            {
                jsonID = jsonID.Substring(0, jsonID.Length - 1);
                jsonIntervenant = jsonIntervenant.Substring(0, jsonIntervenant.Length - 1);
                jsonDateIntervention = jsonDateIntervention.Substring(0, jsonDateIntervention.Length - 1);
                jsonPlanifie = jsonPlanifie.Substring(0, jsonPlanifie.Length - 1);
                jsonDemandeur = jsonDemandeur.Substring(0, jsonDemandeur.Length - 1);
                jsonMotif = jsonMotif.Substring(0, jsonMotif.Length - 1);
                jsonDureeIntervention = jsonDureeIntervention.Substring(0, jsonDureeIntervention.Length - 1);
                jsonNoteFrais = jsonNoteFrais.Substring(0, jsonNoteFrais.Length - 1);
                jsonPrimeIntervention = jsonPrimeIntervention.Substring(0, jsonPrimeIntervention.Length - 1);
                jsonPrimeDimanche = jsonPrimeDimanche.Substring(0, jsonPrimeDimanche.Length - 1);
                jsonValide = jsonValide.Substring(0, jsonValide.Length - 1);
            }

            jsonID += "]";
            jsonIntervenant += "]";
            jsonDateIntervention += "]";
            jsonPlanifie += "]";
            jsonDemandeur += "]";
            jsonMotif += "]";
            jsonDureeIntervention += "]";
            jsonNoteFrais += "]";
            jsonPrimeIntervention += "]";
            jsonPrimeDimanche += "]";
            jsonValide += "]";

            string jsonText = "{" + jsongranularite + "," + jsonID + "," + jsonIntervenant + "," + jsonDateIntervention + "," + jsonPlanifie + "," + jsonDemandeur + "," + jsonMotif + "," + jsonDureeIntervention + "," + jsonNoteFrais + "," + jsonPrimeIntervention + "," + jsonPrimeDimanche + "," + jsonValide + "}";

            return Json(jsonText);
        }

        //[HttpPost]
        public int SendMail(string body, string tabId)
        {
            // Décodage du code HTML
            string bodyHTML = body.Replace("%2F", "/").Replace("%139", "<").Replace("%155", ">");

            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd = connection.CreateCommand();
            string[] name = User.Identity.Name.Split('\\');
            cmd.CommandText = "SELECT email FROM glpi_useremails WHERE users_id IN (SELECT id FROM glpi_users WHERE name ='" + name[1] + "')";
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            MailMessage mail = new MailMessage();

            while (reader.Read())
            {
                mail.To.Add(reader.GetString(0));          
            }

            mail.From = new MailAddress("dlf-s12vm09.indicateurSI@refresco.com");
            mail.Subject = "Rapport interventions en heures non ouvrées - " + DateTime.Now.ToString("dd-MM-yyyy");
            mail.Body = bodyHTML;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "dlf-sk8vm03.refresco.local";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = true; // si false, décommenter la ligne de dessous
            //smtp.Credentials = new System.Net.NetworkCredential("username", "password"); // Renseigner le nom d'utilisateur et le mot de passe
            smtp.EnableSsl = false;
            smtp.Send(mail);

            // TODO - Role RSI pour valider les interventions

            string[] tabIds = tabId.Split('|');

            for (int i = 0; i < tabIds.Count() - 1; i++)
            {
                var IDTest = int.Parse(tabIds[i]);
                var editIntervention = from eI in db.Interventions
                                       where eI.InterventionID == IDTest
                                       select eI;

                foreach (var intervention in editIntervention)
                {
                    intervention.Valide = true;
                }

            }

            db.SaveChanges();

            return 0;
        }
    }
}