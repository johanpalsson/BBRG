using BBRG.Models;
using BBRG.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace BBRG.Controllers
{
    public class SavingPlansController : Controller
    {

        private ApplicationDbContext _context;

        public SavingPlansController()
        {
            _context = new ApplicationDbContext();
        }

        // Post sp
        public ActionResult NewSavingPlan()
        {

            SavingPlanAssessmentView viewModel = new SavingPlanAssessmentView();
            viewModel.SavingPlan = new SavingPlan();

            var regions = _context.Regions
                .ToList();

            viewModel.RegionLookUp = regions;
            return View(viewModel);
        }


        // GET: Assessments
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var savingPlan = _context.SavingPlans
                .Where(x => x.AssessmentUser.Id == userId)
                .ToList();

            if (savingPlan == null)
            {
                return View("Home");
            }

            return View(savingPlan);
        }

        [HttpPost]
        public JsonResult SaveList(string RegionId)
        {
            var urlBuilder = new UrlHelper(Request.RequestContext);
            var url = urlBuilder.Action("Index", "Assessments");
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);

            string[] arr = RegionId.Split(',');
            List<Region> region = new List<Region>();


            var assessment = new Assessment
            {
                AssessmentUser = user,
                RegionList=null
            };

            _context.Assessments.Add(assessment);
            _context.SaveChanges();

            return Json(new { status = "success", redirectUrl = Url.Action("Detail", "assessments", assessment) });

        }

        [Authorize]
        public ActionResult Detail(int id)
        {
            var savingPlan = _context.SavingPlans
                .SingleOrDefault(m => m.Id == id);

            if (savingPlan == null)
            {
                return HttpNotFound();
            }

            return View(savingPlan);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var savingPlan = _context.SavingPlans
                .SingleOrDefault(m => m.Id == id);

            if (savingPlan == null)
            {
                return HttpNotFound();
            }
            var viewModel = new SavingPlanAssessmentView
            {
                Heading = "Edit Saving Plan",
                Id = savingPlan.Id,

                RegionLookUp = _context.Regions.ToList(),
                RegionId = savingPlan.Region.Id

            };
            return View("NewSavingPlan", viewModel);
        }


        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(SavingPlan viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel2 = new SavingPlan
        //        {
        //            Id = viewModel.Id,
        //            RE = _context.Regions.ToList(),


        //        };
        //        return View("NewSavingPlan", viewModel);
        //    }

        //    var userId = User.Identity.GetUserId();
        //    var region = _context.Regions.Single(x => x.Id == viewModel.RegionId);


        //    var savingPlan = _context.SavingPlans.Single(m => m.Id == viewModel.Id && m.AssessmentUser.Id == userId);

        //    savingPlan.Region = region;

        //    _context.SaveChanges();

        //    return RedirectToAction("Detail", savingPlan);
        //}
    }

}