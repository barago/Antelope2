using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Antelope.DTOs.HSE
{
    public class FicheSecuriteActionRecherche
    {
        public FicheSecurite FicheSecurite {get; set;}
        public ActionQSE ActionQSE { get; set; }
        public CauseQSE CauseQSE { get; set; }

        public static Expression<Func<FicheSecuriteActionRecherche, bool>> PlanActionAttente
        {
            get
            {
                return x =>
                (!x.FicheSecurite.WorkFlowASEValidee
                    && x.FicheSecurite.WorkFlowAttenteASEValidation
                    && !x.FicheSecurite.WorkFlowASERejetee
                    && !x.FicheSecurite.WorkFlowCloturee
                    && !x.FicheSecurite.WorkFlowFicheSecuriteCloturee)
                ||
                (!x.FicheSecurite.WorkFlowASEValidee &&
                    x.FicheSecurite.WorkFlowAttenteASEValidation &&
                    !x.FicheSecurite.WorkFlowASERejetee &&
                    x.FicheSecurite.WorkFlowCloturee &&
                    !x.FicheSecurite.WorkFlowFicheSecuriteCloturee);
            }
        }

        public static Expression<Func<FicheSecuriteActionRecherche, bool>> PlanActionValide
        {
            get
            {
                return x =>
                    x.FicheSecurite.WorkFlowASEValidee
                    && !x.FicheSecurite.WorkFlowAttenteASEValidation
                    && !x.FicheSecurite.WorkFlowASERejetee
                    && !x.FicheSecurite.WorkFlowCloturee
                    && !x.FicheSecurite.WorkFlowFicheSecuriteCloturee;
            }
        }
        public static Expression<Func<FicheSecuriteActionRecherche, bool>> PlanActionRejete
        {
            get
            {
                return x =>
                    !x.FicheSecurite.WorkFlowASEValidee
                    && !x.FicheSecurite.WorkFlowAttenteASEValidation
                    && x.FicheSecurite.WorkFlowASERejetee
                    && !x.FicheSecurite.WorkFlowCloturee
                    && !x.FicheSecurite.WorkFlowFicheSecuriteCloturee;
            }
        }

        public static Expression<Func<FicheSecuriteActionRecherche, bool>> PlanActionCloture
        {
            get
            {
                return x =>
                x.FicheSecurite.WorkFlowASEValidee
                && !x.FicheSecurite.WorkFlowAttenteASEValidation
                && !x.FicheSecurite.WorkFlowASERejetee
                && x.FicheSecurite.WorkFlowCloturee
                && !x.FicheSecurite.WorkFlowFicheSecuriteCloturee;
            }
        }

        public static Expression<Func<FicheSecuriteActionRecherche, bool>> FicheSecuriteCloture
        {
            get
            {
                return x => x.FicheSecurite.WorkFlowFicheSecuriteCloturee;
            }
        }
        public static Expression<Func<FicheSecuriteActionRecherche, bool>> NouvelleFiche
        {
            get
            {
                return x =>
                (!x.FicheSecurite.WorkFlowASEValidee
                    && !x.FicheSecurite.WorkFlowAttenteASEValidation
                    && !x.FicheSecurite.WorkFlowASERejetee
                    && !x.FicheSecurite.WorkFlowCloturee
                    && !x.FicheSecurite.WorkFlowFicheSecuriteCloturee)
                ||
                (!x.FicheSecurite.WorkFlowASEValidee
                    && !x.FicheSecurite.WorkFlowAttenteASEValidation
                    && !x.FicheSecurite.WorkFlowASERejetee
                    && x.FicheSecurite.WorkFlowCloturee
                    && !x.FicheSecurite.WorkFlowFicheSecuriteCloturee);
            }
        }
    }
}