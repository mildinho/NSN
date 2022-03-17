using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSN.Models;
using NSN.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NSN.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly Repository.Interface.IEmpresa _repositoryEmpresa;
        public EstoqueController(Repository.Interface.IEmpresa empresa)
        {
            _repositoryEmpresa = empresa;
        }



        public IActionResult Produtos()
        {

            var empresa = _repositoryEmpresa.Listar_TodasEmpresas();
            ViewBag.Empresas = empresa.Select(a => new SelectListItem(a.Nome_Fantasia, a.Id.ToString()));


            var stqRepo = new StqRepository();
            List<Stq> dados = stqRepo.Pesquisa_Referencia_Item("ZM501");
            Stq mostra = dados.Select(m => m).Where(mo => mo.filial == "00").SingleOrDefault();
            return View("Produtos", mostra);

        }
    }
}
