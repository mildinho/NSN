using NSN.Biblioteca;
using NSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSN.Repository
{
    public class StqRepository : Interface.IStq
    {
        public Conexao ConnFur = new Conexao(ConexaoName.Furacao);

        public Stq Pesquisa_Referencia_Item(string creferencia)
        {
            string csql = @"select refx,descr,pvenda,pultrep as pcusto,dtcadastro from stq where refx = :cRefx";
            var param = ConnFur.DefineParametros();

            ConnFur.AbreConexao();
            param.Add("cRefx", creferencia);
            Stq retorno = ConnFur.SQLSelect<Stq>(csql, param).SingleOrDefault();
            ConnFur.FechaConexao();
            return retorno;
        }

        public List<Stq> Pesquisa_Referencia_Lista(string cReferencia)
        {
            throw new NotImplementedException();
        }
    }
}
