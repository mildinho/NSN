using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSN.Biblioteca;
using NSN.Models;
using System;
using System.Diagnostics;


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

            if (ConnFur.AbreConexao())
            {
                string x = @"select codcli from clientes where codcli = 10125";

                ConnFur.Conn.BeginTransaction();

                int id = Convert.ToInt32(ConnFur.Conn.ExecuteScalar(x));


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
