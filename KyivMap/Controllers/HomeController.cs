namespace KyivMap.Controllers
{
	using System.Web.Mvc;
	using Models;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View(new TestModel());
		}
	}
}