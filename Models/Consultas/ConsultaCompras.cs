using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Padaria_Bread.Models.Consultas
{
    public class ConsultaCompras
    {
        public int id { get; set; }

        [Display(Name = "Cliente")]
        public string cliente { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "Produto")]
        public string produto { get; set; }

        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }
    }
}
