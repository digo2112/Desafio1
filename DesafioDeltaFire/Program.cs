using DesafioDeltaFire.Context;
using DesafioDeltaFire.Repositories;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services;
using DesafioDeltaFire.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "MyInMemoryDb"));

//apagar

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDetalhesVendaRepository, DetalhesVendaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();

builder.Services.AddScoped<ICriarVendaService, CriarVendaService>();

builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IRelatorioVendasService, RelatorioVendasService>();
builder.Services.AddScoped<IAdicionarDetalheVenda, AdicionarDetalheVenda>();

//para arrumar a dataadddd
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<ApplyFormatInSwagger>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    context.SeedData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();