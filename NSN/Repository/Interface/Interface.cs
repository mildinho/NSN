using NSN.Models;
using System.Collections.Generic;


namespace NSN.Repository.Interface
{
    public interface IStq 
    {
        public List<Stq> Pesquisa_Referencia_Item(string cReferencia);
        public List<Stq> Pesquisa_Referencia_Lista(string cReferencia);
    }
    public interface ICliente
    {
        public Stq Pesquisa_Clientes_Codigo(int nCodCli);
    }


    public interface IEmpresa
    {
        public List<Empresa> Listar_TodasEmpresas();
    }

}
