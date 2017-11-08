using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    /// <summary>
    /// Définition complémentaire de la fiche sécurité.
    /// </summary>
    public partial class FicheSecurite
    {
        public static Expression<Func<FicheSecurite, bool>> PlanActionAttente
        {
            get
            {
                return x =>
                (x.WorkFlowASEValidee == false
                    && x.WorkFlowAttenteASEValidation
                    && !x.WorkFlowASERejetee
                    && !x.WorkFlowCloturee
                    && !x.WorkFlowFicheSecuriteCloturee)
                ||
                (!x.WorkFlowASEValidee &&
                    x.WorkFlowAttenteASEValidation &&
                    !x.WorkFlowASERejetee &&
                    x.WorkFlowCloturee &&
                    !x.WorkFlowFicheSecuriteCloturee);
            }
        }

        public static Expression<Func<FicheSecurite, bool>> PlanActionValide
        {
            get
            {
                return x =>
                    x.WorkFlowASEValidee
                    && !x.WorkFlowAttenteASEValidation
                    && !x.WorkFlowASERejetee
                    && !x.WorkFlowCloturee
                    && !x.WorkFlowFicheSecuriteCloturee;
            }
        }
        public static Expression<Func<FicheSecurite, bool>> PlanActionRejete
        {
            get
            {
                return x =>
                    !x.WorkFlowASEValidee
                    && !x.WorkFlowAttenteASEValidation
                    && x.WorkFlowASERejetee
                    && !x.WorkFlowCloturee
                    && !x.WorkFlowFicheSecuriteCloturee;
            }
        }

        public static Expression<Func<FicheSecurite, bool>> PlanActionCloture
        {
            get
            {
                return x =>
                x.WorkFlowASEValidee
                && !x.WorkFlowAttenteASEValidation
                && !x.WorkFlowASERejetee
                && x.WorkFlowCloturee
                && !x.WorkFlowFicheSecuriteCloturee;
            }
        }

        public static Expression<Func<FicheSecurite, bool>> FicheSecuriteCloture
        {
            get
            {
                return x => x.WorkFlowFicheSecuriteCloturee;
            }
        }
        public static Expression<Func<FicheSecurite, bool>> NouvelleFiche
        {
            get
            {
                return x =>
                (!x.WorkFlowASEValidee
                    && !x.WorkFlowAttenteASEValidation
                    && !x.WorkFlowASERejetee
                    && !x.WorkFlowCloturee
                    && !x.WorkFlowFicheSecuriteCloturee)
                ||
                (!x.WorkFlowASEValidee
                    && !x.WorkFlowAttenteASEValidation
                    && !x.WorkFlowASERejetee
                    && x.WorkFlowCloturee
                    && !x.WorkFlowFicheSecuriteCloturee);
            }
        }

        public List<string> Actions { get; set; }

    }
}
