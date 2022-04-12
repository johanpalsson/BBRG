using System.Collections.Generic;

namespace BBRG.Models
{
    public class Portfolio
    {
        public Portfolio()
        {
            SecuritiesTypes = new List<SecurityType>();
        }
        public int PortfolioId { get; set; }
        public ApplicationUser AssessmentUser { get; set; }
        public List<SecurityType> SecuritiesTypes { get; set; }
    }
}