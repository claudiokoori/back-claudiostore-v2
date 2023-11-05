using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIClaudioStore.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public int Estoque { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
