using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using SIGEBI.Infrastructure.Repositories;
using SIGEBI.Application.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión a la base de datos
builder.Services.AddDbContext<SigebiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRecursoRepository, RecursoRepository>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<IPenalizacionRepository, PenalizacionRepository>();
builder.Services.AddScoped<INotificacionRepository, NotificacionRepository>();
builder.Services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();


// Servicios
builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<RecursoServicio>();
builder.Services.AddScoped<PrestamoServicio>();
builder.Services.AddScoped<DevolucionServicio>();
builder.Services.AddScoped<PenalizacionServicio>();
builder.Services.AddScoped<NotificacionServicio>();
builder.Services.AddScoped<ReporteServicio>();

var app = builder.Build();

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