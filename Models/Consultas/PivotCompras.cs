using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Padaria_Bread.Models.Consultas
{
    public class PivotCompras
    {
        public int id { get; set; }

        [Display(Name = "Cliente")]
        public string cliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Produto 1")]
        public double produto1 { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Produto 2")]
        public double produto2 { get; set; }
    }
}
