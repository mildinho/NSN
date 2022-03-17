using Microsoft.AspNetCore.Mvc;
using NSN.Models;
using NSN.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NSN.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Produtos()
        {
            var stqRepo = new StqRepository();
            List<Stq> dados = stqRepo.Pesquisa_Referencia_Item("ZM501");
            Stq mostra = dados.Select(m => m).Where(mo => mo.filial == "00").SingleOrDefault();
            return View("Produtos", mostra);

        }
    }
}
