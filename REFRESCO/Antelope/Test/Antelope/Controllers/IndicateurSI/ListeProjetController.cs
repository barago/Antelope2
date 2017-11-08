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
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.IndicateurSI
{
    public class ListeProjetController : Controller
    {
        private AntelopeEntities db = new AntelopeEntities();
        //
        // GET: /SupportListeProjet/
        public ActionResult ListeProjet()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/ListeProjet.cshtml");
        }

        public ActionResult StartPage()
        {
            return JsonTab(2, "Fonctionnel");
        }

        public JsonResult JsonTab(int etat, string serviceSI)
        {
            var projets = from p in db.Projets select p;

            if (etat == 0) // projets en cours
            {
                projets = from p in db.Projets
                          where p.DateCloture == null && p.Service == serviceSI
                          select p;
            }
            else //projets clos
            {
                projets = from p in db.Projets
                          where p.DateCloture != null && p.Service == serviceSI
                          select p;
            }

            projets = projets.OrderBy(p => p.ProjetID);

            List<Projet> listeProjet = projets.ToList();

            string JsonText = "{";
            string JsonID = "\"ID\":[";
            string JsonCommentaire = "\"Commentaire\":[";
            string JsonNomProjet = "\"NomProjet\":[";
            string JsonProchaineEtape = "\"ProchaineEtape\":[";
            string JsonStatutVisage = "\"StatutVisage\":[";
            string JsonStatutCouleur = "\"StatutCouleur\":[";
            string JsonDateOuverture = "\"DateOuverture\":[";
            string JsonDateCloture = "\"DateCloture\":[";

            int i = 0;

            for (i = 0; i < listeProjet.Count; i++)
            {
                JsonID += listeProjet[i].ProjetID + ",";
                JsonCommentaire += "\"" + listeProjet[i].Commentaire + "\",";
                JsonNomProjet += "\"" + listeProjet[i].NomProjet + "\",";
                JsonProchaineEtape += "\"" + listeProjet[i].ProchaineEtape + "\",";
                JsonStatutVisage += listeProjet[i].StatutVisage + ",";
                JsonStatutCouleur += listeProjet[i].StatutCouleur + ",";
                JsonDateOuverture += "\"" + listeProjet[i].DateOuverture + "\",";
                JsonDateCloture += "\"" + listeProjet[i].DateCloture + "\",";
            }

            if (i > 0)
            {
                JsonID = JsonID.Substring(0, JsonID.Length - 1);
                JsonCommentaire = JsonCommentaire.Substring(0, JsonCommentaire.Length - 1);
                JsonNomProjet = JsonNomProjet.Substring(0, JsonNomProjet.Length - 1);
                JsonProchaineEtape = JsonProchaineEtape.Substring(0, JsonProchaineEtape.Length - 1);
                JsonStatutVisage = JsonStatutVisage.Substring(0, JsonStatutVisage.Length - 1);
                JsonStatutCouleur = JsonStatutCouleur.Substring(0, JsonStatutCouleur.Length - 1);
                JsonDateOuverture = JsonDateOuverture.Substring(0, JsonDateOuverture.Length - 1);
                JsonDateCloture = JsonDateCloture.Substring(0, JsonDateCloture.Length - 1);
            }

            JsonID += "]";
            JsonCommentaire += "]";
            JsonNomProjet += "]";
            JsonProchaineEtape += "]";
            JsonStatutVisage += "]";
            JsonStatutCouleur += "]";
            JsonDateOuverture += "]";
            JsonDateCloture += "]";

            JsonText += JsonID + "," + JsonCommentaire + "," + JsonNomProjet + "," + JsonProchaineEtape + "," + JsonStatutVisage + "," + JsonStatutCouleur + "," + JsonDateOuverture + "," + JsonDateCloture + "}";

            return Json(JsonText);
        }

        public int AjouterTable(string NProjet, int SCouleur, int SVisage, string Com, string PEtape, string DOuverture, string ServiceSI)
        {
            var projets = from p in db.Projets
                          where p.NomProjet == NProjet
                          select p;

            Projet ProjetSI = new Projet()
            {
                // TODO -- vérifier l'unicité du nom projet
                NomProjet = NProjet,
                StatutCouleur = SCouleur,
                StatutVisage = SVisage,
                Commentaire = Com,
                ProchaineEtape = PEtape,
                DateOuverture = DOuverture,
                DateCloture = null,
                Service = ServiceSI
            };

            db.Projets.Add(ProjetSI);
            db.SaveChanges();

            return 0;

        }

        public int EditerTable(int ID, string NProjet, int SCouleur, int SVisage, string Com, string PEtape, string DOuverture, string ServiceSI)
        {
            var editProjets = from p in db.Projets
                              where p.ProjetID == ID
                              select p;

            foreach (var projet in editProjets)
            {
                projet.NomProjet = NProjet;
                projet.StatutCouleur = SCouleur;
                projet.StatutVisage = SVisage;
                projet.Commentaire = Com;
                projet.ProchaineEtape = PEtape;
                projet.DateOuverture = DOuverture;
                projet.Service = ServiceSI;
            }

            db.SaveChanges();

            return 0;

        }

        public int SupprimerTable(int ID)
        {

            var deleteProjets = from p in db.Projets
                                where p.ProjetID == ID
                                select p;

            foreach (var projet in deleteProjets)
            {
                db.Projets.Remove(projet);
            }

            db.SaveChanges();

            return 0;
        }

        public int CloreProjet(int ID)
        {
            var editProjets = from p in db.Projets
                              where p.ProjetID == ID
                              select p;

            foreach (var projet in editProjets)
            {
                DateTime d = DateTime.Now;
                string dateCloture = d.ToString("dd-MM-yy");
                projet.DateCloture = dateCloture;
            }

            db.SaveChanges();

            return 0;
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