using System.ComponentModel.DataAnnotations;

namespace DesafioDeltaFire.DTOs
{
    public class UpdateDetalhesVendaDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}