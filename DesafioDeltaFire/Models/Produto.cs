using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioDeltaFire.Models
{
    public class Produto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }
        [Required]

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        [Required]
        public int Estoque { get; set; }
        [Required]


        public int Fornecedor { get; set; }
        [Required]
        public DateOnly DataCadastro { get; set; }
        [Required]
        public DateOnly DataValidade { get; set; }
        //ta dando erro com o tamnho da string
        public string? CaminhoUrl { get; set; }
        public int? Categoria { get; set; }
    }
}
