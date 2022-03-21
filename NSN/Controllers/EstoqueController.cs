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
        StqRepository STQRepository = new StqRepository();
        List<Stq> dados;

        public EstoqueController(Repository.Interface.IEmpresa empresa)
        {

            _repositoryEmpresa = empresa;



        }



        public IActionResult Produtos(string Filial = "00")
        {

            var empresa = _repositoryEmpresa.Listar_TodasEmpresas();
            ViewBag.Empresas = empresa.Select(a => new SelectListItem(a.Nome_Fantasia, a.Filial,(a.Filial==Filial)));
            ViewBag.Filial = Filial;

            
            Stq dados = STQRepository.Pesquisa_Referencia_Item("ZM501",Filial).SingleOrDefault();
            return View("Produtos", dados);

        }


    }
}
