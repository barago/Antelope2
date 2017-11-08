using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.FicheSecuriteViewModels
{
    public class FicheSecuritePaginatedList
    {

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public List<FicheSecurite> AllFicheSecurite { get; set; }

    }
}