var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injeta serviços
builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<ICarrinhoService, CarrinhoService>();
builder.Services.AddSingleton<IPedidoService, PedidoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
