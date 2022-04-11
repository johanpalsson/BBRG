using BBRG.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BBRG.ViewModels
{
    public class SavingPlanAssessmentView
    {

        public SavingPlanAssessmentView()
        {
            Region = new Region();
        }

        public SavingPlan SavingPlan { get; set; }
        public int Id { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
        [Required]
        public string[] RegionList { get; set; }
        public IEnumerable<Region> RegionLookUp { get; set; }


        public string Heading { get; set; }
    }
}