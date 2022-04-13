using BBRG.Models;
using System.Collections.Generic;

namespace BBRG.ViewModels
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel()
        {
            SecurityTypeList = new List<SecurityType>();
        }

        public int Id { get; set; }
        public int SecTypeId { get; set; }

        public List<SecurityType> SecurityTypeList { get; set; }
        public IEnumerable<SecurityType> SecTypeLookUp { get; set; }
        public string Heading { get; set; }

    }
}