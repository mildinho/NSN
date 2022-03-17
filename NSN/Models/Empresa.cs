using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSN.Models
{
    public class Empresa
    {
        [Display(Name = "Código")]
        public int Id { get; set; }


        [Display(Name = "Empresa")]
        public string Cod_Empresa { get; set; }
        
        [Display(Name = "Estabelecimento")]
        public string Cod_Estab { get; set; }

        
        [Display(Name = "Filial")]
        public string Filial { get; set; }

        
        [Display(Name = "UF")]
        public string UF { get; set; }


        [Display(Name = "Fantasia")]
        public string Nome_Fantasia { get; set; }

    }
}
