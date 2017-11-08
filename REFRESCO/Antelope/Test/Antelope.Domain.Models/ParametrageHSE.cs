using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class ParametrageHSE
    {
        public Int32 Id { get; set; }
        public string EmailDiffusionFS { get; set; }
        public string EmailValidationRejetPlanActionFS { get; set; }
        public string EmailDiffusionPlanAction { get; set; }
        public Boolean IsEmailDiffusion { get; set; }

    }
}
