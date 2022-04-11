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

        public SavingPlan SavingPlan { get; set; }
    }
}