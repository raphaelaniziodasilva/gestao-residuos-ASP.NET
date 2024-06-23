using gestao_residuos_ASP.NET.Data;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de configuração
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);

// Configuração do contexto do Entity Framework Core com a string de conexão do appsettings.Development.json
builder.Services.AddDbContext<GestaoResiduosContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("GestaoConnection")));

// Registrar o serviço ContatoService
builder.Services.AddScoped<IContatoService, ContatoService>();

// Outros serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurações do pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar migrações para criar o banco de dados e tabelas se necessário
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GestaoResiduosContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
