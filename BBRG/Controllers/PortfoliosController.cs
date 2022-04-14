using BBRG.Models;
using BBRG.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BBRG.Controllers
{
    public class PortfoliosController : Controller
    {
        private ApplicationDbContext _context;

        public PortfoliosController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Portfolios
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var portfolio = _context.Portfolios
                .Include(x => x.AssessmentUser)
                .Include(x => x.SecuritiesTypes)
                .Where(x => x.AssessmentUser.Id == userId)
                .ToList();
            return View(portfolio);
        }

        // GET: Portfolios/ 1
        public ActionResult Detail(int id)
        {
            var portfolio = _context.Portfolios
                .Include(m => m.SecuritiesTypes)
                .SingleOrDefault(m => m.PortfolioId == id);

            if (portfolio == null)
            {
                return HttpNotFound();

            }

            var portfolioViewModel = new PortfolioViewModel
            {
                SecTypeLookUp = _context.SecurityTypes.ToList()
            };

            return View(portfolioViewModel);
        }


        public ActionResult NewPortfolio()
        {
            var secTypes = _context.SecurityTypes.ToList();
            var portfolioViewModel = new PortfolioViewModel
            {

                SecTypeLookUp = secTypes,
                SecurityTypeList = new List<SecurityType>()
            };

            return View(portfolioViewModel);
        }


        [HttpPost]
        public ActionResult Save(PortfolioViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);

            var portfolio = new Portfolio
            {
                AssessmentUser = user,
                SecuritiesTypes = viewModel.SecurityTypeList

            };

            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();

            return RedirectToAction("Detail", portfolio);
        }


    }
}