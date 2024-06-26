using gestao_residuos_ASP.NET.Data;
using gestao_residuos_ASP.NET.Interface;
using gestao_residuos_ASP.NET.Mapping;
using gestao_residuos_ASP.NET.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);

builder.Services.AddDbContext<GestaoResiduosContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("GestaoConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<ILixoService, LixoService>();
builder.Services.AddScoped<IColetaAgendadaService, ColetaAgendadaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
