using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioDeltaFire.Models
{
    public class Cliente
    {
        public Cliente()
        {
            HistoricoVendas = new List<Venda>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(80)]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }

        [StringLength(80)]
        public string? Complemento { get; set; }
        [Required]
        [StringLength(80)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(2)]
        public string Estado { get; set; }
        [Required]

        public string Cep { get; set; }
        [Required]
        public DateOnly DataCadastro { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
        [Required]

        public bool IsAtivo { get; set; }
        [JsonIgnore]
        public List<Venda> HistoricoVendas { get; set; } = new List<Venda>();

        //aqui pq não mexe com a venda em sim, so registra quantas teve
        public void RegisterSale(Venda venda)
        {
            HistoricoVendas.Add(venda);
        }
    }
}
