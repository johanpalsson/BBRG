using System.Collections.Generic;

namespace BBRG.Models
{
    public class SavingPlan
    {
        public SavingPlan()
        {
        }

        public SavingPlan(List<Region> regionList)
        {
            RegionList = regionList;
        }

        public int Id { get; set; }

        public ApplicationUser AssessmentUser { get; set; }
        public IEnumerable<Region> RegionLookUp { get; set; }
        public bool IsActive { get; set; }
        public byte RegionId { get; set; }
        public Region Region { get; set; }
        public List<Region> RegionList { get; set; }
    }
}