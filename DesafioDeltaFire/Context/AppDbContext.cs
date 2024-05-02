using Microsoft.EntityFrameworkCore;
using DesafioDeltaFire.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection.Emit;

namespace DesafioDeltaFire.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "MyInMemoryDb");
            }
        }

        public void SeedData()
        {
            var guid = new Guid();
            Cliente.Add(new Models.Cliente()
            {
                //Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
                Id = guid,
                //  Id = Guid.NewGuid(),
                Nome = "Rodrigo Borges",
                Cpf = "33355588800",
                Telefone = "54993090000",
                Email = "rodrigo@gmail.com",
                Rua = "Rua Antonio Corsetti",
                Complemento = "",
                Numero = 54,
                Cidade = "Caxias do Sul",
                Estado = "RS",
                Cep = "95012080",
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),//2024-04-29,
                DataNascimento = new DateOnly(2000, 1, 1),//1989-06-22,
                IsAtivo = true
            }); 
            
            Cliente.Add(new Models.Cliente()
            {
                Id = new Guid("7c9e6679-7425-8888-944b-e07fc1f90ae7"),
                //Id = Guid.NewGuid(),
                Nome = "Joao da Silva",
                Cpf = "11122233344",
                Telefone = "54993094321",
                Email = "joaosilva@gmail.com",
                Rua = "Rua Julio de Castilhos",
                Complemento = "apto 32",
                Numero = 1243,
                Cidade = "Caxias do Sul",
                Estado = "RS",
                Cep = "900012080",
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),//2024-04-29,
                DataNascimento = new DateOnly(1988, 7, 3),//1989-06-22,
                IsAtivo = true
            });

            Cliente.Add(new Models.Cliente()
            {
                Id = new Guid("6ba7b831-9dad-11d1-80b4-00c04fd430c8"),
                Nome = "Fernanda Lima",
                Cpf = "12345678900",
                Telefone = "54993091234",
                Email = "rodrigo@gmail.com",
                Rua = "Rua Antonio Corsetti",
                Complemento = "Fundos",
                Numero = 54,
                Cidade = "Sao Paulo",
                Estado = "SP",
                Cep = "90120804",
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),//2024-04-29,
                DataNascimento = new DateOnly(1955, 4, 1),//1989-06-22,
                IsAtivo = false
            });
            
            

            SaveChanges();
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<DetalhesVenda> DetalhesVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //para ignorar as tabelas de login e role do identity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();

            modelBuilder.Entity<Cliente>()
             .ToTable("Clientes")
             .HasKey(cliente => cliente.Id);

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.Nome)
              .HasMaxLength(80)
             .IsRequired();

            modelBuilder.Entity<Cliente>()
                 .Property(cliente => cliente.Cpf)
                 .HasMaxLength(11)
                  .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.Telefone)
              .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Cliente>()
               .Property(cliente => cliente.Email)
               .HasColumnType("nvarchar(max)")
               .IsRequired();

            modelBuilder.Entity<Cliente>()
               .Property(cliente => cliente.Rua)
               .HasMaxLength(80)
               .IsRequired();

            modelBuilder.Entity<Cliente>()
               .Property(cliente => cliente.Numero)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
               .Property(cliente => cliente.Complemento)
               .HasMaxLength(80);

            modelBuilder.Entity<Cliente>()
             .Property(cliente => cliente.Cidade)
              .HasMaxLength(80)
              .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.Estado)
              .HasMaxLength(2)
              .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.Cep)
              .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.DataCadastro)
              .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.DataNascimento)
              .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(cliente => cliente.IsAtivo)
              .IsRequired();

            modelBuilder.Entity<Produto>()
                 .ToTable("Produtos")
                 .HasKey(produto => produto.Id);

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.Nome)
                .HasMaxLength(80)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.Descricao)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.Estoque)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.Fornecedor)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.DataCadastro)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.DataValidade)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.CaminhoUrl)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Produto>()
                .Property(produto => produto.Categoria);
            
            modelBuilder.Entity<Venda>()
                .ToTable("Vendas")
                .HasKey(venda => venda.Id);

            modelBuilder.Entity<Venda>()
                .Property(venda => venda.NotaFiscal)
                .IsRequired();

            modelBuilder.Entity<Venda>()
                .Property(venda => venda.ClienteId)
                .IsRequired();

            modelBuilder.Entity<Venda>()
                .Property(venda => venda.DataVenda)
                .IsRequired();
            /*
            modelBuilder.Entity<Venda>()
                .Property(venda => venda.Quantidade);*/

            modelBuilder.Entity<Venda>()
                .Property(venda => venda.Total)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Venda>();

            modelBuilder.Entity<DetalhesVenda>()
                .ToTable("DetalhesVendas")
                .HasKey(detalhesVenda => detalhesVenda.Id);

            modelBuilder.Entity<DetalhesVenda>()
                .Property(detalhesVenda => detalhesVenda.ProdutoId)
                .IsRequired();

            modelBuilder.Entity<DetalhesVenda>()
                .Property(detalhesVenda => detalhesVenda.VendaId)
                .IsRequired();

            modelBuilder.Entity<DetalhesVenda>()
                .Property(detalhesVenda => detalhesVenda.Quantidade)
                .IsRequired();
        }
    }
}
