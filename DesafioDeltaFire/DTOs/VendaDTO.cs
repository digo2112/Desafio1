using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDeltaFire.DTOs
{
    public class VendaDTO
    {
        [Required]
        public Guid ClienteId { get; set; }
        [Required]
        public int NotaFiscal { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }
    
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public List<DetalhesVendaDTO> DetalhesVenda { get; set; }
    }
}
