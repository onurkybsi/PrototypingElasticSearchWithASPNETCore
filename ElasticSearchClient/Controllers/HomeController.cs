using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
