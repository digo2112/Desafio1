using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioDeltaFire.Models
{
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public int NotaFiscal { get; set; }

        [Required]
        public Guid ClienteId { get; set; }
        [JsonIgnore]
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        //public int Quantidade { get; set; }

        [JsonIgnore]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [JsonIgnore]
        public ICollection<DetalhesVenda> DetalhesVenda { get; set; }
    }
}
