using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Dominio
{
    public class Cliente
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Nascimento")]
        public DateTime data_nascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Endereço")]
        public string rua { get; set; }

        [Range(minimum: 1, maximum: 9999)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Número")]
        public int numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        public ICollection<Venda> vendas { get; set; }
    }
}
