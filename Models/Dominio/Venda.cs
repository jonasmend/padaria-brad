using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Dominio
{
    public class Venda
    {
        public int id { get; set; }

        [Display(Name = "Cliente")]
        public int id_cliente { get; set; }

        [Display(Name = "Produto")]
        public int id_produto { get; set; }

        [Display(Name = "Cliente")]
        public Cliente cliente { get; set; }

        [Display(Name = "Produto")]
        public Produto produto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor do produto")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double valorProduto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor da venda")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double valorVenda { get; set; }
    }
}