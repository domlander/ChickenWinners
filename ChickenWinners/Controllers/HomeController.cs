namespace ChickenWinners.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using ChickenWinners.Models;

    public class HomeController : Controller
    {
        ResultsDbContext context = new ResultsDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Results()
        {
            return View(context.Fixtures.ToList());
        }

        public ActionResult EditResults(int id)
        {
            return View();
        }

        public ActionResult MyGames()
        {
            return View();
        }

        public ActionResult JoinCreate()
        {
            return View();
        }
    }
}