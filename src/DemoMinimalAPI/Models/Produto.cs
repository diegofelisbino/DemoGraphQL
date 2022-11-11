using System.ComponentModel.DataAnnotations;

namespace DemoMinimalAPI.Models
{
    public class Produto 
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }        
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Fornecedor? Fornecedor { get; set; }
    }
}
