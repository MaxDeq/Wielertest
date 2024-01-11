using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.data;
using Test.Models;

namespace Test.Controllers
{
	public class SeingeversController : Controller
	{

        private readonly WielerwedstrijdDbContext dbContext;

        public SeingeversController(WielerwedstrijdDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
		{
            var seingevers = dbContext.Signalmen.ToList();
            return View(seingevers);
		}


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var seingevers = dbContext
                .Signalmen
                .SingleOrDefault(o => o.SignalmanId == id);

            if (seingevers is null)
            {
                return RedirectToAction("Index");
            }

            return View(seingevers);
        }

        [HttpPost]
        public IActionResult Edit(int id, Signalman signalman)
        {
            if (!ModelState.IsValid)
            {
                return View(signalman);
            }

            var eenSignalman = dbContext
                .Signalmen
                .SingleOrDefault(o => o.SignalmanId == id);

            if (eenSignalman is null)
            {
                return RedirectToAction("Index");
            }

            eenSignalman.Name = signalman.Name;
            eenSignalman.FirstName = signalman.FirstName;
            eenSignalman.LocationId = signalman.LocationId;
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var signalman = dbContext.Signalmen.SingleOrDefault(o => o.SignalmanId == id);
            if (signalman is null)
            {
                return RedirectToAction("index");
            }
            return View(signalman);
        }
        [HttpPost("[controller]/Delete/{id:int?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var signalman = dbContext.Signalmen.SingleOrDefault(o => o.SignalmanId == id);
            if (signalman is null)
            {
                return RedirectToAction("index");
            }
            dbContext.Signalmen.Remove(signalman);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
