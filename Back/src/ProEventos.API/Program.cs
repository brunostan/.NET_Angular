using Microsoft.EntityFrameworkCore;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Entity Framework Core
builder.Services.AddDbContext<ProEventosContext>(context
    => context.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração dos serviços da aplicação
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IEventoPersist, EventoPersist>();

// Configuração do MVC e JSON
builder.Services.AddControllers().AddNewtonsoftJson(config
    => config.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Configuração do CORS
builder.Services.AddCors();

// Configuração da documentação Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuração do CORS, redirecionamento HTTPS, autorização e rotas
app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();