using System.Collections.Generic;

namespace BBRG.Models
{
    public class Assessment
    {
        public int Id { get; set; }

        public ApplicationUser AssessmentUser { get; set; }

        public byte RegionId { get; set; }
        public Region Region { get; set; }
        public List<Region> RegionList { get; set; }

        public int SecurityTypeId { get; set; }
        public SecurityType SecurityType { get; set; }
        public List<SecurityType> SecurityTypeList { get; set; }

        public int SavingPlanId { get; set; }
        public SavingPlan SavingPlan { get; set; }
        public List<SavingPlan> SavingPlanList { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public List<Portfolio> PortfolioList { get; set; }



    }
}