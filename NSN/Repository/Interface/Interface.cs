using NSN.Models;
using System.Collections.Generic;


namespace NSN.Repository.Interface
{
    public interface IStq 
    {
        public Stq Pesquisa_Referencia_Item(string cReferencia);
        public List<Stq> Pesquisa_Referencia_Lista(string cReferencia);
    }
    public interface IClientes
    {
        public Stq Pesquisa_Clientes_Codigo(int nCodCli);
    }
}
