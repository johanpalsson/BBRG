using BBRG.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BBRG.ViewModels
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel()
        {
            SecurityTypeList = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public int SecTypeId { get; set; }

        public IList<SelectListItem> SecurityTypeList { get; set; }
        public IEnumerable<SecurityType> SecTypeLookUp { get; set; }
        public string Heading { get; set; }

    }
}