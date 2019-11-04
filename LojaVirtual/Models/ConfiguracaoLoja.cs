using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models
{
    public class ConfiguracaoLoja
    {
        public int Id { get; set; }

        [Display(Name = "Percentual de Lucro")]
        public decimal PercentualLucro { get; set; }

        [Display(Name = "Despesa Geral da Loja")]
        [Required(ErrorMessage = "Despesa Geral Obrigatória")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Custo do Produto inválido")]
        public decimal CustoDespesa { get; set; }

    }
}
