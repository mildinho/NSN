using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSN.Biblioteca;
using NSN.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {

            if (await ConnFur.AbreConexao(true))
            {
                string x = @"select codcli from clientes where codcli = :nCodCli";
                var param = ConnFur.DefineParametros();

                param.Add("nCodcli", 10125);


                var obj = await ConnFur.SQLSelect<int>(x, param);
                var id = obj.SingleOrDefault();

                

                ConnFur.Transacao.Commit();

                await ConnFur.FechaConexao();
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
