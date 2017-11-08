using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Services.HSE
{
    public class FicheSecuriteServices
    {

        private AntelopeEntities db = new AntelopeEntities();

        public void FicheSecuriteOpenOrClose(ActionQSE actionQSE)
        {
            var queryFicheSecurite = from a in db.ActionQSEs
                                     join c in db.CauseQSEs on a.CauseQSEId equals c.CauseQSEId
                                     join fs in db.FicheSecurites on c.FicheSecuriteId equals fs.FicheSecuriteID
                                     where a.ActionQSEId == actionQSE.ActionQSEId
                                     select fs;
            FicheSecurite ficheSecuriteForAction = queryFicheSecurite.FirstOrDefault();

            var queryActionQSEsForFicheSecurite = from a in db.ActionQSEs
                                                  join c in db.CauseQSEs on a.CauseQSEId equals c.CauseQSEId
                                                  join fs in db.FicheSecurites on c.FicheSecuriteId equals fs.FicheSecuriteID
                                                  where fs.FicheSecuriteID == ficheSecuriteForAction.FicheSecuriteID
                                                  select a;
            List<ActionQSE> AllActionQSEForFicheSecurite = queryActionQSEsForFicheSecurite.ToList();

            Boolean IsFicheSecuriteCloturee = true;
            foreach (ActionQSE ActionQSEForFicheSecurite in AllActionQSEForFicheSecurite)
            {
                IsFicheSecuriteCloturee = (ActionQSEForFicheSecurite.ClotureDate != null) ? IsFicheSecuriteCloturee : false;
            }

            ficheSecuriteForAction.WorkFlowCloturee = IsFicheSecuriteCloturee;

            db.SaveChanges();
        } 


        public static void AddTriParamsToViewBag(dynamic viewBag, String ordreTri)
        {
            viewBag.TriParametreCode = String.IsNullOrEmpty(ordreTri) ? "Code_desc" : "";
            viewBag.TriParametreType = ordreTri == "Type" ? "Type_desc" : "Type";
        }

        public static IQueryable<FicheSecurite> TriFicheSecurites(IQueryable<FicheSecurite> ficheSecurites, string ordreTri)
        {

            switch (ordreTri)
            {
                case "Code_desc":
                    ficheSecurites = ficheSecurites.OrderByDescending(f => f.Code);
                    break;
                case "Type":
                    ficheSecurites = ficheSecurites.OrderBy(f => f.Type);
                    break;
                case "Type_desc":
                    ficheSecurites = ficheSecurites.OrderByDescending(f => f.Type);
                    break;
                default:
                    ficheSecurites = ficheSecurites.OrderBy(f => f.Code);
                    break;
            }

            return ficheSecurites;
        }

    }

}