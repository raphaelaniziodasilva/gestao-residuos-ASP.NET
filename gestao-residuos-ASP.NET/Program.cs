using gestao_residuos_ASP.NET.Data;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Mapping;
using gestao_residuos_ASP.NET.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de configura��o
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);

// Configura��o do contexto do Entity Framework Core com a string de conex�o do appsettings.Development.json
builder.Services.AddDbContext<GestaoResiduosContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("GestaoConnection")));

// Adiciona o servi�o AutoMapper com o perfil de mapeamento
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Registrar o servi�o ContatoService
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<ILixoService, LixoService>();

// Outros servi�os
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��es do pipeline de solicita��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar migra��es para criar o banco de dados e tabelas se necess�rio
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
