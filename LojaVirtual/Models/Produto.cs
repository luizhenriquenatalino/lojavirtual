using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaVirtual.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Nome do Produto obrigatório")]
        [StringLength(maximumLength: 50, ErrorMessage = "Nome do Produto muito longa")]
        public string Nome { get; set; }

        [JsonIgnore]
        [Display(Name = "Preço de Venda")]
        [Required(ErrorMessage = "Preço de Venda obrigatório")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Preço de Venda inválido")]
        public decimal PrecoVenda { get; set; }

        [JsonIgnore]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição do Produto obrigatório")]
        [StringLength(maximumLength: 200, ErrorMessage = "Descrição do Produto muito longa")]
        public string Descricao { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Custo do Produto obrigatório")]        
        [Range(1, Int32.MaxValue, ErrorMessage = "Custo do Produto inválido")]
        public decimal Custo { get; set; }

        [JsonIgnore]
        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Imagem do Produto obrigatório")]
        public string CaminhoImagem { get; set; }

    }
}
