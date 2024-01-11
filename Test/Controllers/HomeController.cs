using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.data;
using Test.Models;

namespace Test.Controllers
{
	public class HomeController : Controller
	{
		private readonly WielerwedstrijdDbContext dbContext;

		public HomeController(WielerwedstrijdDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var signalman = dbContext.Signalmen.ToList();
			return View(signalman);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Edit()
		{
			return View();
		}
	}
}
