using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSN.Biblioteca;
using NSN.Models;
using NSN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSN.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly string Key = "Configuracao_Tema";
        private readonly Repository.Interface.IEmpresa _repositoryEmpresa;
        private readonly StqRepository STQRepository = new StqRepository();
        private readonly Cookie _cookie;

        public EstoqueController(Repository.Interface.IEmpresa empresa, Cookie cookie)
        {

            _repositoryEmpresa = empresa;
/*
            _cookie = cookie;
            _cookie.Cadastrar(Key, "Vamos fuder...");

            string minharolha = "";
            minharolha = _cookie.Consultar(Key);

            */

        }


        public IActionResult Produtos(string Referencia, string Filial = "00")
        {

            var empresa = _repositoryEmpresa.Listar_TodasEmpresas();
            ViewBag.Empresas = empresa.Select(a => new SelectListItem(a.Nome_Fantasia, a.Filial, (a.Filial == Filial)));
            ViewBag.Filial = Filial;


            Stq dados = new Stq();

            if (!String.IsNullOrEmpty(Referencia))
            {
                dados = STQRepository.Pesquisa_Referencia_Item(Referencia, Filial).FirstOrDefault();
                if (dados == null)
                {
                    dados = new Stq();

                }
            }
            
            return View("Produtos", dados);

        }

    }
}
