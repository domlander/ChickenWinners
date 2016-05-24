namespace ChickenWinners.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using ChickenWinners.Models;
    using ChickenWinners.ViewModels;

    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext dbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public HomeController()
        {
            this.dbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.dbContext));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateGame()
        {
            CreateGameViewModel createGameViewModel = new CreateGameViewModel()
            {
                Sports = dbContext.Sports.ToList()
            };

            return View(createGameViewModel);
        }

        [HttpPost]
        public ActionResult CreateGame(CreateGameViewModel createGameViewModel)
        {
            var currentUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                Sport sport = dbContext.Sports.Where(s => s.Id == createGameViewModel.Sport)
                                              .FirstOrDefault();

                League newLeague = new League()
                {
                    Name = createGameViewModel.Name,
                    State = LeagueState.Preparation,
                    Sport = sport,
                    StartWeek = createGameViewModel.StartWeek
                };

                LeaguePlayer leaguePlayer = new LeaguePlayer()
                {
                    League = newLeague,
                    User = UserManager.FindById(User.Identity.GetUserId())
                };

                dbContext.Leagues.Add(newLeague);
                dbContext.LeaguePlayer.Add(leaguePlayer);

                dbContext.SaveChanges();
            }
            else
            {

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult JoinGame()
        {
            return View();
        }

        public PartialViewResult _joinGame(JoinGameViewModel JoinGameViewModel)
        {
            // find if there is exists a league in preparation with given league code
            League foundLeague = dbContext.Leagues.Where(l => l.Id == JoinGameViewModel.Id && l.State == LeagueState.Preparation)
                                                  .FirstOrDefault();

            string response;

            if (foundLeague != null)
            {
                string userId = User.Identity.GetUserId();

                LeaguePlayer alreadyInLeague = dbContext.LeaguePlayer.Where(
                    lp => lp.League.Id == foundLeague.Id && lp.User.Id == userId).FirstOrDefault();

                if (alreadyInLeague != null)
                {
                    response = "You already belong to this league.";
                }
                else
                {
                    // league code is a match. Add the user to the league.
                    AddUserToLeague(foundLeague, User.Identity.GetUserId());

                    response = "Successfully added to league.";
                }
            }
            else
            {
                response = "League not found. Please try again.";
            }

            return PartialView("_joinGameResponse", response);
        }

        public void AddUserToLeague(League league, string userId)
        {
            dbContext.LeaguePlayer.Add(new LeaguePlayer()
            {
                League = league,
                User = UserManager.FindById(userId)
            });

            dbContext.SaveChanges();
        }

        public ActionResult MemberProfile()
        {
            return View();
        }
    }
}