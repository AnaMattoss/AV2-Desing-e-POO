using PerfumeStore.Application.Services;
using PerfumeStore.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injeta servi�os
builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<ICarrinhoService, CarrinhoService>();
builder.Services.AddSingleton<IClienteService, ClienteService>();
builder.Services.AddSingleton<IPedidoService, PedidoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
