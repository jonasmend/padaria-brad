using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Dominio
{
    public class Produto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição do produto")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Estoque")]
        public int estoque { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Preço")]
        public double preco { get; set; }

        public ICollection<Venda> vendas { get; set; }
    }
}
