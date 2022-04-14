using BBRG.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BBRG.ViewModels
{
    public class AssessmentViewModel
    {

        public int Id { get; set; }

        public SavingPlanAssessmentView SavingPlanViewwModel { get; set; }
        public PortfolioViewModel PortfolioViewModel { get; set; }

        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
        public List<Portfolio> PortfolioList { get; set; }

        public int SecTypeId { get; set; }
        public SecurityType SecurityType { get; set; }
        public List<SecurityType> SecurityTypeList { get; set; }
        public IEnumerable<SecurityType> SecTypeLookUp { get; set; }

        public SavingPlan SavingPlan { get; set; }
        public int SavingPlanId { get; set; }
        public List<Portfolio> SavingPlanList { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
        public List<Region> RegionList { get; set; }
        [Required]
        public IEnumerable<Region> RegionLookUp { get; set; }

        public string Heading { get; set; }

        //public string Action
        //{
        //    get
        //    {   // Lambda expression below represent an anomous method
        //        // func is a deligate that represent an anomous method
        //        Expression<Func<AssessmentsController, ActionResult>> update = (c => c.Update(this));
        //        //Expression<Func<AssessmentsController, ActionResult>> save = (c => c.Save(this));

        //        var action = (Id != 0) ? update : save;
        //        return (action.Body as MethodCallExpression).Method.Name;

        //        // above instead of below
        //        //return (Id != 0) ? "Update" : "Save";
        //    }
        //}
    }

}