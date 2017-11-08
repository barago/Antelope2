using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Repositories.HSE
{
    public class DialogueSecuriteRepository
    {

        public AntelopeEntities _db { get; set; }

        public DialogueSecuriteRepository() : this(new AntelopeEntities())
        {

        }

        public DialogueSecuriteRepository(AntelopeEntities db)
        {
            _db = db;
        }

        public DialogueSecurite Get(Int32 id)
        {
            DialogueSecurite DialogueSecurite = _db.DialogueSecurites.SingleOrDefault(r => r.Id == id);
            return DialogueSecurite;
        }


        public DataTableViewModel<DialogueSecurite> GetFromParams(Dictionary<string, string> DataTableParameters)
        {

            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);

            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);
            string ParameterAtelier = DataTableParameters["atelier"];
            DateTime? ParameterDateDebut = null;
            DateTime? ParameterDateFin = null;


            if (DataTableParameters["dateDebut"] != "")
            {
                try
                {
                    ParameterDateDebut = DateTime.Parse(DataTableParameters["dateDebut"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateFin"] != "")
            {
                try
                {
                    ParameterDateFin = DateTime.Parse(DataTableParameters["dateFin"]);
                }
                catch (Exception e)
                {

                }
            }

            var queryDialogueSecurite = from ds in _db.DialogueSecurites
                                     //orderby nc.Id
                                     select ds;


            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryDialogueSecurite = queryDialogueSecurite.Where(q => q.SiteId == ParameterSiteId);
            }
            if (ParameterAtelier != null && ParameterAtelier != "")
            {
                queryDialogueSecurite = queryDialogueSecurite.Where(q => q.Atelier == ParameterAtelier);
            }


            int RecordsFiltered = queryDialogueSecurite.Count();
            int RecordsTotal = _db.DialogueSecurites.Count();

            queryDialogueSecurite = queryDialogueSecurite.OrderBy(i => i.Id);

            if (ParameterLength != -1)
            {
                queryDialogueSecurite = queryDialogueSecurite.Skip(ParameterStart).Take(ParameterLength);
            }

            var AllDialogueSecurite = queryDialogueSecurite.ToList();

            DataTableViewModel<DialogueSecurite> DataTableViewModel = new DataTableViewModel<DialogueSecurite>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllDialogueSecurite
            };


            return DataTableViewModel;

        }

    }
}