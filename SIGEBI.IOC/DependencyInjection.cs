using Microsoft.Extensions.DependencyInjection;
using SIGEBI.Domain.Repository;
using SIGEBI.Infrastructure.Repositories;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;

namespace SIGEBI.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRecursoRepository, RecursoRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            services.AddScoped<IPenalizacionRepository, PenalizacionRepository>();
            services.AddScoped<INotificacionRepository, NotificacionRepository>();
            services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IRecursoServicio, RecursoServicio>();
            services.AddScoped<IPrestamoServicio, PrestamoServicio>();
            services.AddScoped<IDevolucionServicio, DevolucionServicio>();
            services.AddScoped<IPenalizacionServicio, PenalizacionServicio>();
            services.AddScoped<INotificacionServicio, NotificacionServicio>();
            services.AddScoped<IReporteServicio, ReporteServicio>();
            return services;
        }
    }
}