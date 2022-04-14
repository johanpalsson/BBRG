using BBRG.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BBRG.ViewModels
{
    public class SavingPlanAssessmentView
    {

        public SavingPlanAssessmentView()
        {
            RegionList = new List<Region>();
        }

        public int Id { get; set; }

        public SavingPlan SavingPlan { get; set; }


        public int RegionId { get; set; }
        public Region Region { get; set; }
        [Required]
        public List<Region> RegionList { get; set; }
        public IEnumerable<Region> RegionLookUp { get; set; }
        public string Heading { get; set; }
    }
}