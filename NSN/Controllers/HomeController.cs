using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSN.Biblioteca;
using NSN.Models;
using System.Diagnostics;
using System.Linq;


namespace NSN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Conexao ConnFur = new Conexao(ConexaoName.Furacao);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            if (ConnFur.AbreConexao(true))
            {
                string x = @"select codcli from clientes where codcli = :nCodCli";
                long nCodcli = 10125;


                var id = ConnFur.SQLSelect<int>(x, new { nCodcli }).SingleOrDefault();

                ConnFur.Transacao.Commit();

                ConnFur.FechaConexao();
            }

            return View();
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
