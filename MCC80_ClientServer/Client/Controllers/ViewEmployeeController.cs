using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ViewEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
