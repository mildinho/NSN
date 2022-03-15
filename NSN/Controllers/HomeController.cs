using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSN.Biblioteca;
using NSN.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NSN.Repository;
using System.Collections.Generic;

namespace NSN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var stqRepo = new StqRepository();
            List<Stq> dados = stqRepo.Pesquisa_Referencia_Item("ZM501");
            Stq mostra = dados.Select(m => m).Where(mo => mo.filial == "00").SingleOrDefault();
            return View(mostra);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
