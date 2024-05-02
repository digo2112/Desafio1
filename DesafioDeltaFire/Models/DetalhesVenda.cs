using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioDeltaFire.Models
{
    public class DetalhesVenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [JsonIgnore]
        public Venda Venda { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        public Guid VendaId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }



        [Required]
        public int Quantidade { get; set; }
        [JsonIgnore]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        [JsonIgnore]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorUnitario { get; set; }
    }
}
