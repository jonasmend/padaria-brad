using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Consultas
{
    public class TotalCompras
    {
        public int id { get; set; }

        [Display(Name = "Produto")]
        public string descProduto { get; set; }

        [Display(Name = "Total Comprado")]
        public int totalComprado { get; set; }
    }
}
