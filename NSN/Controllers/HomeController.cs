using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSN.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NSN.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
