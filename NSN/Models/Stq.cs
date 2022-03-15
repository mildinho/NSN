using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSN.Models
{
    public class Stq
    {
        public string Refx { get; set; }
        public string Descr { get; set; }
        public long pVenda { get; set; }
        public long pCusto { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
