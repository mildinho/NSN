using NSN.Biblioteca;
using NSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSN.Repository
{
    public class EmpresaRepository : Interface.IEmpresa
    {
        public Conexao ConnFur = new Conexao(ConexaoName.Furacao);

        public List<Empresa> Listar_TodasEmpresas()
        {


            string csql = @"select id, Cod_Empresa, Cod_Estab, Filial, UF, Nome_Fantasia
                            FROM nota_empresa where ATIVO = :Ativo AND IMOVEIS = :Imoveis Order by Nome_Fantasia";
            var param = ConnFur.DefineParametros();

            List<Empresa> retorno = new List<Empresa>();
            if (ConnFur.AbreConexao())
            {
                try
                {
                    param.Add("Ativo", 'S');
                    param.Add("Imoveis", 'N');
                    retorno = ConnFur.SQLSelect<Empresa>(csql, param).ToList();
                }
                finally
                {
                    ConnFur.FechaConexao();
                }
            }
            return retorno;
        }

    }
}
