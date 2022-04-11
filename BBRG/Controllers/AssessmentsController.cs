using BBRG.Models;
using BBRG.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BBRG.Controllers
{
    public class AssessmentsController : Controller
    {
        private ApplicationDbContext _context;

        public AssessmentsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult NewAssessment()
        {
            var regions = _context.Regions.ToList();
            var sp_ViewModel = new SavingPlanAssessmentView
            {
                RegionLookUp = regions
            };
            var viewModel = new AssessmentViewModel
            {
                Heading = "New Assessment",
                RegionLookUp = regions,
                SavingPlanViewwModel = sp_ViewModel

            };
            return View(viewModel);
        }



        // GET: Assessments
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var assessments = _context.Assessments
                .Where(x => x.AssessmentUser.Id == userId)
                .Include(m => m.SavingPlan)
                .ToList();

            if (assessments == null)
            {
                return View("Home");
            }

            return View(assessments);
        }



        [HttpPost]
        public ActionResult Save(AssessmentViewModel viewModel)
        {
            //var userId = User.Identity.GetUserId();

            //var user = _context.Users.Single(u => u.Id == userId);

            //string[] regions = viewModel.RegionList;

            //var assessment = new Assessment
            //{
            //    AssessmentUser = user,
            //    RegionList = regions

            //};

            //_context.Assessments.Add(assessment);
            //_context.SaveChanges();

            //return RedirectToAction("Detail", "assessments");
            return null;
        }

        [Authorize]
        public ActionResult Detail(int id)
        {
            var assessment = _context.Assessments
                .Include(m => m.Region)
                .Include(m => m.SavingPlan)
                .SingleOrDefault(m => m.Id == id);

            if (assessment == null)
            {
                return HttpNotFound();
            }

            return View(assessment);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            var assessment = _context.Assessments
                .SingleOrDefault(m => m.Id == id);

            if (assessment == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AssessmentViewModel
            {
                Heading = "Edit Assessment",
                Id = assessment.Id,

                RegionLookUp = _context.Regions.ToList(),
                RegionId = assessment.Region.Id

            };


            return View("NewAssessment", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AssessmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel2 = new AssessmentViewModel
                {
                    Id = viewModel.Id,
                    RegionLookUp = _context.Regions.ToList(),


                };
                return View("NewAssessment", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var region = _context.Regions.Single(x => x.Id == viewModel.RegionId);


            var assessment = _context.Assessments.Single(m => m.Id == viewModel.Id && m.AssessmentUser.Id == userId);

            assessment.Region = region;

            _context.SaveChanges();

            return RedirectToAction("Detail", assessment);
        }
    }


}