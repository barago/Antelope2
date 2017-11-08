using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Threading;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using Antelope.Services.Socle;
using Antelope.Repositories.Socle;
using Antelope.DTOs.Socle;


namespace Antelope.Services.HSE
{
    public class EmailService
    {

        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        private string GetEmailFor(string parametrage, string trigramme)
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            string email = "";

            ParametrageHSE ParametrageHSE = db.ParametrageHSEs.FirstOrDefault();

            switch (parametrage)
            {
                case "DiffusionFicheSecurite" :
                    email = ParametrageHSE.EmailDiffusionFS;
                    break;
                case "RejetPlanActionFicheSecurite":
                    email = ParametrageHSE.EmailValidationRejetPlanActionFS;
                    break;
                case "ValidationPlanActionFicheSecurite":
                    email = ParametrageHSE.EmailValidationRejetPlanActionFS;
                    break;
                case "DiffusionPlanActionFicheSecurite":
                    email = ParametrageHSE.EmailDiffusionPlanAction;
                    break;
            }
            
            if (email == "SELF")
            {
                email = _activeDirectoryUtilisateurRepository.GetCurrentUserEmail();
            }

            string emailWithoutSiteSpecialCaracters = SiteSpecialCaractersReplace(email, trigramme);

            return emailWithoutSiteSpecialCaracters;
        }

        private string SiteSpecialCaractersReplace(string emailString, string trigramme)
        {
            string emailWithSiteCaracters = emailString.Replace("&&&", trigramme);
            return emailWithSiteCaracters;
        }


        public void SendEmailDiffusionFicheSecurite (FicheSecurite FicheSecurite){

            MailMessage mail = new MailMessage();

            // TODO : Créer une classe pour construire des adresses ... ?
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string urlToFicheSecurite = url.Action("Edit", "FicheSecurite", new System.Web.Routing.RouteValueDictionary(new { id = FicheSecurite.FicheSecuriteID }), "http", HttpContext.Current.Request.Url.Host);


            string ActionImmediate2 = "";
            if(FicheSecurite.ActionImmediate2 != null && FicheSecurite.ActionImmediate2 != ""){
                ActionImmediate2 = "<div>&nbsp;&nbsp;-&nbsp;" + FicheSecurite.ActionImmediate2 + "</div>";
            }

            String body = "<div style='font-family: Verdana, sans-serif;'><H1 style='background-color:#C42031;color:#FFFFFF;text-align:center;border-radius: 25px;'>Nouvelle Fiche Sécurité à " + FicheSecurite.Site.Trigramme + "</H1>" +
                "<div><span style='font-weight: bold;text-decoration: underline;'>" + db.FicheSecuriteTypes.Find(FicheSecurite.FicheSecuriteTypeId).Nom + "</span>" +
                " de <span style='font-weight: bold;text-decoration: underline;'>" + FicheSecurite.PersonneConcernee.Prenom + " " + FicheSecurite.PersonneConcernee.Nom + "</span></div>" +
                "<br/>" +
                "<div style='font-weight: bold;text-decoration: underline;'>Description :</div>" +
                "<div>" + FicheSecurite.Description + "</div>" +
                "<br/>" +
                "<div style='font-weight: bold;text-decoration: underline;'>Action(s) immédiate(s) :</div>" +
                "<div>&nbsp;&nbsp;-&nbsp;" + FicheSecurite.ActionImmediate1 + "</div>" +
                ActionImmediate2 +
                "<br/>"+
                "<div> Lien vers la fiche  : " + urlToFicheSecurite + "</div></div>";

            MailAddress from = new MailAddress("Sezar@refresco.com");
            string subject = "Nouvelle Fiche Sécurité à " + FicheSecurite.Site.Trigramme;


            string to = GetEmailFor("DiffusionFicheSecurite", FicheSecurite.Site.Trigramme); //db.Sites.Find(FicheSecurite.SiteId).Trigramme);

            to = addFicheSecuriteResponsableEmailToString(to, FicheSecurite);

            if (to != "" && to != null)
            {
                SendEmail(from, subject, body, to);
            }
        }

        public void SendEmailDiffusionPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == ficheSecurite.SiteId);

            string to = GetEmailFor("DiffusionPlanActionFicheSecurite", db.Sites.Find(ficheSecurite.SiteId).Trigramme );

            to = addFicheSecuriteResponsableEmailToString(to, ficheSecurite);

            to = addActionResponsableEmailToString(to, ficheSecurite);

            MailAddress from = new MailAddress("Sezar@refresco.com");
            string subject = "Diffusion Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite " + ficheSecurite.Code + " vient d'être diffusé</H4> </br>";

            if (to != "" && to != null)
            {
                SendEmail(from, subject, body, to);
            }

        }

        public void SendEmailValidationPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == ficheSecurite.SiteId);

            string to = GetEmailFor("ValidationPlanActionFicheSecurite", db.Sites.Find(ficheSecurite.SiteId).Trigramme);

            to = addFicheSecuriteResponsableEmailToString(to, ficheSecurite);

            to = addActionResponsableEmailToString(to, ficheSecurite);

            MailAddress from = new MailAddress("Sezar@refresco.com");
            string subject = "Validation Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite " + ficheSecurite.Code + " vient d'être validé</H4> </br></br>";
            body += "</br> Voici les actions à réaliser : </br></br>";

            foreach(CauseQSE Cause in ficheSecurite.CauseQSEs){
                foreach (ActionQSE Action in Cause.ActionQSEs)
                {
                    body += "Responsable : " + Action.Responsable.Prenom + " " + Action.Responsable.Nom + "</br>Action : " + Action.Description + "</br>Date butoir : " + Action.DateButoireInitiale;
                }
            }

            if (to != "" && to != null)
            {
                SendEmail(from, subject, body, to);
            }

        }

        public void SendEmailRejetPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == ficheSecurite.SiteId);

            string to = GetEmailFor("RejetPlanActionFicheSecurite", db.Sites.Find(ficheSecurite.SiteId).Trigramme);

            to = addFicheSecuriteResponsableEmailToString(to, ficheSecurite);

            to = addActionResponsableEmailToString(to, ficheSecurite);

            MailAddress from = new MailAddress("Sezar@refresco.com");
            string subject = "Rejet Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite "+ ficheSecurite.Code +" vient d'être rejeté</H4> Voici la cause du rejet : </br>" + ficheSecurite.WorkFlowASERejeteeCause;

            if (to != "" && to != null)
            {
                SendEmail(from, subject, body, to);
            }

        }

        public void SendEmailDiffusionDialogueSecurite(DialogueSecurite dialogueSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == dialogueSecurite.SiteId);

            string to = GetEmailFor("DiffusionFicheSecurite", db.Sites.Find(dialogueSecurite.SiteId).Trigramme);

            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string urlToDialogueSecurite= url.Action("Edit", "DialogueSecurite", new System.Web.Routing.RouteValueDictionary(new { id = dialogueSecurite.Id }), "http", HttpContext.Current.Request.Url.Host);

            MailAddress from = new MailAddress("Sezar@refresco.com");

            //Contournement, je n'arrive pas à charger les objets "lieu" dans le "DialogueSecurite", alors que l'ID est bien présent ...
            Lieu lieu = db.Lieux.Find(dialogueSecurite.LieuId);
            Zone zone = db.Zones.Find(dialogueSecurite.ZoneId);

            string subject = "Nouveau Dialogue Sécurité " + dialogueSecurite.Code;

            string body = "<div style='font-family: Verdana, sans-serif;'><H2 style='background-color:#FD9910;color:#FFFFFF;text-align:center;border-radius: 25px;'>Le Dialogue Sécurité " + dialogueSecurite.Code + " vient d'être diffusé.</H2></div>" +
                    "<br/>" +
                    "<table><tbody>"; 

            body += "<tr><td>Dialogués : </td><td>1 / </td><td>" + dialogueSecurite.Entretenu1.Prenom + "</td><td>" + dialogueSecurite.Entretenu1.Nom + "</td><td> du service : </td><td>" + dialogueSecurite.ServiceType3.Nom + "</td></tr>";

            if (dialogueSecurite.Entretenu2.Nom != null)
            {
                body += "<tr><td></td><td>2 / </td><td>" + dialogueSecurite.Entretenu2.Prenom + "</td><td>" + dialogueSecurite.Entretenu2.Nom + "</td><td> du service : </td><td>" + dialogueSecurite.ServiceType4.Nom + "</td></tr>";
            }
            if (dialogueSecurite.Entretenu3.Nom != null)
            {
                body += "<tr><td></td><td>3 / </td><td>" + dialogueSecurite.Entretenu3.Prenom + "</td><td>" + dialogueSecurite.Entretenu3.Nom + "</td><td> du service : </td><td>" + dialogueSecurite.ServiceType5.Nom + "</td></tr>";

            }
            body += "<tr></tr>";
            body += "<tr><td>Dialogueurs :</td><td>1 / </td><td>" + dialogueSecurite.Dialogueur1.Prenom + "</td><td>" + dialogueSecurite.Dialogueur1.Nom + "</td><td> du service : </td><td>" + dialogueSecurite.ServiceType.Nom + "</td></tr>";       

            if (dialogueSecurite.Dialogueur2.Nom != null)
            {
                body += "<tr><td></td><td>2 / </td><td>" + dialogueSecurite.Dialogueur2.Prenom + "</td><td>" + dialogueSecurite.Dialogueur2.Nom + "</td><td> du service : </td><td>" + dialogueSecurite.ServiceType1.Nom + "</td></tr>";
            }
            if (dialogueSecurite.Dialogueur3.Nom != null)
            {
                body += "<tr><td></td><td>3 / </td><td>" + dialogueSecurite.Dialogueur3.Prenom + "</td><td>" + dialogueSecurite.Dialogueur3.Nom + "</td><td> du service : </td><td>" + dialogueSecurite.ServiceType2.Nom + "</td></tr>";
            }

            body += "</tbody></table>";
            body += "<br/>";
            body += "<div> Thématique : " + dialogueSecurite.Thematique.Nom + "</div>";
            body += "<br/>";
            body += "<table><tbody>" +
                "<tr><td>SITUER</td><td>" + dialogueSecurite.Contexte + "</td></tr>" +
                "<tr><td>OBSERVER</td><td>" + dialogueSecurite.Observation + "</td></tr>" +
                "<tr><td>REFLECHIR</td><td>" + dialogueSecurite.Reflexion + "</td></tr>" +
                "<tr><td>AGIR</td><td>" + dialogueSecurite.Action + "</td></tr>" +
                "</table></tbody>";

            body += "<br/>";
            body += "<div> Zone : " + zone.ZoneType.Nom + "</div>";
            body += "<div> Lieu : " + lieu.Nom + "</div>";
            body += "<br/>";
            body += "<div> Lien vers le dialogue  : " + urlToDialogueSecurite + "</div>";

            if (to != "" && to != null)
            {
                SendEmail(from, subject, body, to);
            }

        }

        private string addFicheSecuriteResponsableEmailToString(String to, FicheSecurite ficheSecurite)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            ActiveDirectoryUtilisateurDTO ResponsableActiveDirectoryUtilisateurDTO;

            ResponsableActiveDirectoryUtilisateurDTO = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUtilisateurByNomPrenom(ficheSecurite.Responsable.Nom, ficheSecurite.Responsable.Prenom);


            String toResponsable = "";

            if (ResponsableActiveDirectoryUtilisateurDTO != null)
            {
               toResponsable = ResponsableActiveDirectoryUtilisateurDTO.email;
            }
            
            if (toResponsable != "" && toResponsable != null)
            {
                if(to != "" && toResponsable != null){
                    to += ",";
                }
                to += toResponsable;
            }

            return to;
        }

        private string addActionResponsableEmailToString(String to, FicheSecurite ficheSecurite)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            ActiveDirectoryUtilisateurDTO ResponsableActiveDirectoryUtilisateurDTO;

            List<Personne> allActionResponsable = new List<Personne>();

            foreach (CauseQSE cause in ficheSecurite.CauseQSEs)
            {
                foreach (ActionQSE action in cause.ActionQSEs)
                {
                    allActionResponsable.Add(action.Responsable);
                }
            }

            for (int i = 0; i < allActionResponsable.Count(); i++)
            {

                String toResponsable = "";
                ResponsableActiveDirectoryUtilisateurDTO = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUtilisateurByNomPrenom(allActionResponsable[i].Nom, allActionResponsable[i].Prenom);


                if (ResponsableActiveDirectoryUtilisateurDTO != null)
                {
                    toResponsable = ResponsableActiveDirectoryUtilisateurDTO.email;
                }

                if (toResponsable != "" && toResponsable != null)
                {
                    if (to != "" && toResponsable != null)
                    {
                        to += ",";
                    }
                    to += toResponsable;
                }
            }

            return to;
        }


        private void SendEmail(MailAddress from, String subject, string body, string to)
        {
            ParametrageHSE ParametrageHSE = db.ParametrageHSEs.FirstOrDefault();

            MailMessage mail = new MailMessage();

            mail.From = from;
            mail.Subject = subject;
            mail.Body = body;
            mail.To.Add(to);
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "dlf-sk8vm03.refresco.local";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = true; // si false, décommenter la ligne de dessous
            //smtp.Credentials = new System.Net.NetworkCredential("username", "password"); // Renseigner le nom d'utilisateur et le mot de passe
            smtp.EnableSsl = false;

            //On crée un nouveau Thread, afin de ne pas attendre l'authentification serveur Exchange pour envoyer le mail.
            Thread T1 = new Thread(delegate()
            {

                try
                {

                    if (ParametrageHSE.IsEmailDiffusion == true)
                    {
                        smtp.Send(mail);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            });
            T1.Start();

        }

    }
}