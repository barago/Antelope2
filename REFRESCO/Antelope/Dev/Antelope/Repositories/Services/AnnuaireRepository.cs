using Antelope.Domain.Models;
using Antelope.DTOs.Services;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

using Antelope.Configurations;

namespace Antelope.Repositories.Services
{
    public class AnnuaireRepository
    {

        public AntelopeEntities _db { get; set; }

        public AnnuaireRepository() : this(new AntelopeEntities())
        {

        }

        public AnnuaireRepository(AntelopeEntities db)
        {
            _db = db;
        }

        public DataTableViewModel<AnnuaireUtilisateurDTO> GetFromParams(Dictionary<string, string> DataTableParameters)
        {

            //Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            //Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);
            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);

            Site Site = _db.Sites.Where(s => s.SiteID == ParameterSiteId).FirstOrDefault();

            String ParameterTrigramme = Site.Trigramme;

            string connectionPrefix = ActiveDirectoryConfig.CurrentConfig.ActiveDirectoryPath;
            DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);

            mySearcher.Filter = "(&(objectCategory=Person)(objectClass=User)";
            mySearcher.Filter += (ParameterTrigramme == null) ? "" : "(company="+ParameterTrigramme+"))";
            mySearcher.PropertiesToLoad.Add("cn");
                    mySearcher.PropertiesToLoad.Add("givenname");
                    mySearcher.PropertiesToLoad.Add("sn");
                    mySearcher.PropertiesToLoad.Add("telephonenumber");
                    mySearcher.PropertiesToLoad.Add("mobile");
                    mySearcher.PropertiesToLoad.Add("title");
                    mySearcher.PropertiesToLoad.Add("mail");

            var results = SafeFindAll(mySearcher);

            mySearcher.Dispose();

            List<AnnuaireUtilisateurDTO> AllAnuaireUtilisateurDTO = new List<AnnuaireUtilisateurDTO>();

            foreach (var result in results)
            {

                AllAnuaireUtilisateurDTO.Add(new AnnuaireUtilisateurDTO()
                {
                    NomEntier = result.Properties["cn"][0].ToString(),
                    Prenom = result.Properties["givenname"][0].ToString(),
                    Nom = (result.Properties["sn"].Count > 0 ) ? result.Properties["sn"][0].ToString() :"",
                    NumInterne = (result.Properties["telephonenumber"].Count > 0) ? result.Properties["telephonenumber"][0].ToString() : "",
                    NumExterne = (result.Properties["mobile"].Count > 0) ? result.Properties["mobile"][0].ToString() : "",
                    Poste = (result.Properties["title"].Count > 0) ? result.Properties["title"][0].ToString() : "",
                    Mail = (result.Properties["mail"].Count > 0) ? result.Properties["mail"][0].ToString() : ""
                });

            }

            Object Response = new { AllAnuaireUtilisateurDTO = AllAnuaireUtilisateurDTO };

            int RecordsFiltered = AllAnuaireUtilisateurDTO.Count();
            int RecordsTotal = AllAnuaireUtilisateurDTO.Count();

            DataTableViewModel<AnnuaireUtilisateurDTO> DataTableViewModel = new DataTableViewModel<AnnuaireUtilisateurDTO>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllAnuaireUtilisateurDTO
            };


            return DataTableViewModel;

        }

        private static IEnumerable<SearchResult> SafeFindAll(DirectorySearcher searcher)
        {
            using (var results = searcher.FindAll())
            {
                foreach (var result in results)
                {
                    yield return (SearchResult)result;
                }
            } // SearchResultCollection will be disposed here
        }




    }
}