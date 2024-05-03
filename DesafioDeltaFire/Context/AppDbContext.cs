using DesafioDeltaFire.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
           // var guid = new Guid();
            Cliente.Add(new Models.Cliente()
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
               // Id = guid,
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

            Produtos.Add(new Models.Produto()
            {
                Id = new Guid("6ba7b835-9dad-11d1-80b4-00c04fd430c8"),
                Nome = "Batata",
                Descricao = "Batata deliciosa",
                Preco = 3.98m,
                Estoque = 1000,
                Fornecedor = 1111,
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),
                DataValidade = new DateOnly(2024, 5, 5),
                CaminhoUrl = "http://exemplo.com/produto.jpg",
                Categoria = 1412
            });

            Produtos.Add(new Models.Produto()
            {
                Id = new Guid("6ba7b836-9dad-11d1-80b4-00c04fd430c8"),
                Nome = "Frango",
                Descricao = "Peito de Frango",
                Preco = 14.98m,
                Estoque = 1000,
                Fornecedor = 2222,
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),
                DataValidade = new DateOnly(2024, 5, 5),//1989-06-22,
                CaminhoUrl = "http://exemplo.com/produto.jpg",
                Categoria = 1234
            });

            Produtos.Add(new Models.Produto()
            {
                Id = new Guid("6ba7b834-9dad-11d1-80b4-00c04fd430c8"),
                Nome = "Abacate",
                Descricao = "Abacate Maduro",
                Preco = 11.98m,
                Estoque = 500,
                Fornecedor = 3333,
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),
                DataValidade = new DateOnly(2024, 5, 5),
                CaminhoUrl = "http://exemplo.com/produto.jpg",
                Categoria = 8090
            });

            Produtos.Add(new Models.Produto()
            {
                Id = new Guid("6ba7b832-9dad-11d1-80b4-00c04fd430c8"),
                Nome = "Detergente",
                Descricao = "Detergente sem cheiro",
                Preco = 1.79m,
                Estoque = 250,
                Fornecedor = 4444,
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),
                DataValidade = new DateOnly(2025, 5, 5),
                CaminhoUrl = "http://exemplo.com/produto.jpg",
                Categoria = 7070
            });

            Venda.Add(new Models.Venda()
            {
                Id = new Guid("bbd62fa0-4f97-11d3-9a0c-0305e82c3301"),
                ClienteId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),//rodrigo
                NotaFiscal = 1515,
                DataVenda = DateTime.ParseExact("02/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            });

            DetalhesVenda.Add(new Models.DetalhesVenda()
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.Parse("6ba7b835-9dad-11d1-80b4-00c04fd430c8"),//batata
                VendaId = new Guid("bbd62fa0-4f97-11d3-9a0c-0305e82c3301"),
                Quantidade = 8
            });

            DetalhesVenda.Add(new Models.DetalhesVenda()
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.Parse("6ba7b832-9dad-11d1-80b4-00c04fd430c8"),//detergente
                VendaId = new Guid("bbd62fa0-4f97-11d3-9a0c-0305e82c3301"),
                Quantidade = 50
            });

            Venda.Add(new Models.Venda()
            {
                Id = new Guid("6ba7b829-9dad-11d1-80b4-00c04fd430c8"),
                ClienteId = Guid.Parse("6ba7b831-9dad-11d1-80b4-00c04fd430c8"),//fernanda
                NotaFiscal = 9999,
                DataVenda = DateTime.ParseExact("02/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            });

            DetalhesVenda.Add(new Models.DetalhesVenda()
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.Parse("6ba7b834-9dad-11d1-80b4-00c04fd430c8"),//detergente
                VendaId = new Guid("6ba7b829-9dad-11d1-80b4-00c04fd430c8"),
                Quantidade = 400
            });

            Venda.Add(new Models.Venda()
            {
                Id = new Guid("6ba7b830-9dad-11d1-80b4-00c04fd430c8"),
                ClienteId = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),//joao
                NotaFiscal = 3055,
                DataVenda = DateTime.ParseExact("02/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            });

            DetalhesVenda.Add(new Models.DetalhesVenda()
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.Parse("6ba7b836-9dad-11d1-80b4-00c04fd430c8"),//frango
                VendaId = new Guid("6ba7b830-9dad-11d1-80b4-00c04fd430c8"),
                Quantidade = 400
            });

            DetalhesVenda.Add(new Models.DetalhesVenda()
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.Parse("6ba7b834-9dad-11d1-80b4-00c04fd430c8"),//abacate
                VendaId = new Guid("6ba7b830-9dad-11d1-80b4-00c04fd430c8"),
                Quantidade = 5
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