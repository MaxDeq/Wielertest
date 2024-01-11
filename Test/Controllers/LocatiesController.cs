using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.data;
using Test.Models;

namespace Test.Controllers
{
	public class LocatiesController : Controller
	{
		private readonly WielerwedstrijdDbContext dbContext;

		public LocatiesController(WielerwedstrijdDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var locations = dbContext.Locations.ToList();
			return View(locations);
		}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }

            dbContext.Locations.Add(location);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
		public IActionResult Edit(int id)
		{
			var location = dbContext
				.Locations
				.SingleOrDefault(o => o.LocationId == id);

			if (location is null)
			{
				return RedirectToAction("Index");
			}

			return View(location);
		}

		[HttpPost]
		public IActionResult Edit(int id, Location location)
		{
			if (!ModelState.IsValid)
			{
				return View(location);
			}

			var eenLocatie = dbContext
				.Locations
				.SingleOrDefault(o => o.LocationId == id);

			if (eenLocatie is null)
			{
				return RedirectToAction("Index");
			}

			eenLocatie.Name = location.Name;
			eenLocatie.Adress = location.Adress;
			eenLocatie.HouseNumber = location.HouseNumber;
			eenLocatie.Description = location.Description;
			dbContext.SaveChanges();

			return RedirectToAction("Index");
		}


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var location = dbContext.Locations
                .Include(l => l.Signalmen)
                .SingleOrDefault(o => o.LocationId == id);
            if (location is null)
            {
                return RedirectToAction("Index");
            }

            if (location.Signalmen.Any())
            {
                return View("ErrorScreen");
            }

            return View(location);
        }
        [HttpPost("[controller]/Delete/{id:int?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var location = dbContext.Locations.SingleOrDefault(o => o.LocationId == id);
            if (location is null)
            {
                return RedirectToAction("Index");
            }
            dbContext.Locations.Remove(location);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}
