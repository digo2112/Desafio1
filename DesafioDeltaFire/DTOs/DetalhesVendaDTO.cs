using System.ComponentModel.DataAnnotations;

namespace DesafioDeltaFire.DTOs
{
    public class DetalhesVendaDTO
    {
        [Required]
        public Guid ProdutoId { get; set; }

        [Required]
        public Guid VendaId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }
    }
}