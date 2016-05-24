using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChickenWinners.Models;
using ChickenWinners.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChickenWinners.Controllers
{
    public class MyLeaguesController : Controller
    {
        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext dbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public MyLeaguesController()
        {
            this.dbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.dbContext));
        }

        // GET: MyLeagues
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _myGames(LeagueState state = LeagueState.Preparation)
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            IEnumerable<League> myLeagues = GetUsersLeagues(user, state).Where(l => l.State == state);
            
            return PartialView("_myGames", myLeagues);
        }

        // GET: MyLeagues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            League league = dbContext.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }

            return View(league);
        }

        // GET: MyLeagues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyLeagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id, Name, StartWeek, LeagueStateId, LeagueState")] 
            League league)
        {
            if (ModelState.IsValid)
            {
                dbContext.Leagues.Add(league);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(league);
        }

        // GET: MyLeagues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            League league = dbContext.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }

            return View(league);
        }

        // POST: MyLeagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([
            Bind(Include = "Id, Name, StartWeek, LeagueStateId, LeagueState")] 
            League league)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(league).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(league);
        }

        // GET: MyLeagues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            League league = dbContext.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }

            return View(league);
        }

        // POST: MyLeagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            League league = dbContext.Leagues.Find(id);
            dbContext.Leagues.Remove(league);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }

            base.Dispose(disposing);
        }

        private IList<League> GetUsersLeagues(ApplicationUser user, LeagueState state)
        {
            IList<League> myLeagues = new List<League>();

            var query = from league in dbContext.Leagues
                        join leaguePlayer in dbContext.LeaguePlayer
                        on league.Id equals leaguePlayer.League.Id
                        where leaguePlayer.User.Id == user.Id && league.State == state
                        select league;

            myLeagues = query.ToList();
            return myLeagues;
        }
    }
}
