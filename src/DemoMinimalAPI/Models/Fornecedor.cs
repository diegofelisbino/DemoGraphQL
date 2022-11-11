using System.ComponentModel.DataAnnotations;

namespace DemoMinimalAPI.Models
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public bool Ativo { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        
        /* EF Relations */
        public IEnumerable<Produto>? Produtos { get; set; }

    }

    public enum TipoFornecedor
    {
        PessoaFisica = 0,
        PessoaJuridica = 1
    }
}
