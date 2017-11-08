using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Antelope.Models.HSE;

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

        public DialogueSecurite Get(int id)
        {
            DialogueSecurite dialogueSecurite = _db.DialogueSecurites.SingleOrDefault(r => r.Id == id);
            return dialogueSecurite;
        }


        public DataTableViewModel<DialogueSecuriteModel> GetFromParams(DialogueSecuriteParams dialogueSecuriteParams)
        {
            try
            {
                var queryDialogueSecurite = from ds in _db.DialogueSecurites
                                            join lieux in _db.Lieux on ds.LieuId equals lieux.LieuID
                                            select new DialogueSecuriteModel
                                            {
                                                Id = ds.Id,
                                                Code = ds.Code,
                                                Date = ds.Date,
                                                Atelier = lieux.Nom,
                                                Contexte = ds.Contexte,
                                                SiteId = ds.SiteId
                                            };

                if (dialogueSecuriteParams.DateDebut.HasValue)
                {

                    queryDialogueSecurite = queryDialogueSecurite.Where(q => q.Date >= dialogueSecuriteParams.DateDebut);

                }

                if (dialogueSecuriteParams.DateFin.HasValue)
                {
                    queryDialogueSecurite = queryDialogueSecurite.Where(q => q.Date <= dialogueSecuriteParams.DateFin);

                }

                if (dialogueSecuriteParams.SiteId != 0)
                {
                    queryDialogueSecurite = queryDialogueSecurite.Where(q => q.SiteId == dialogueSecuriteParams.SiteId);
                }

                if (!string.IsNullOrEmpty(dialogueSecuriteParams.Atelier))
                {
                    string lieu = dialogueSecuriteParams.Atelier.Trim().ToLower();
                    queryDialogueSecurite = queryDialogueSecurite.Where(q => q.Atelier.ToLower().Contains(lieu));
                }

                int recordsFiltered = queryDialogueSecurite.Count();
                int recordsTotal = _db.DialogueSecurites.Count();

                queryDialogueSecurite = queryDialogueSecurite.OrderBy(i => i.Id);

                if (dialogueSecuriteParams.Length != -1)
                {
                    queryDialogueSecurite = queryDialogueSecurite.Skip(dialogueSecuriteParams.Start).Take(dialogueSecuriteParams.Length);
                }

                var allDialogueSecurite = queryDialogueSecurite.ToList();

                DataTableViewModel<DialogueSecuriteModel> dataTableViewModel = new DataTableViewModel<DialogueSecuriteModel>
                {
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsFiltered,
                    data = allDialogueSecurite
                };

                return dataTableViewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class DialogueSecuriteModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Atelier { get; set; }
        public string Contexte { get; set; }
        public int SiteId { get; set; }
    }
}