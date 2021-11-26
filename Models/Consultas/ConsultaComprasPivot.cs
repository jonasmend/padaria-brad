using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Consultas
{
    public class ConsultaComprasPivot
    {
        public int id { get; set; }

        public string produto { get; set; }

        public string cliente { get; set; }

        //public int quantidade { get; set; }

        public double total { get; set; }
    }
}
