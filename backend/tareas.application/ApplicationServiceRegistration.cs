using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareas.application.Context;
using Microsoft.EntityFrameworkCore;
using tareas.application.IServices;
using tareas.application.Services;

namespace tareas.application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((options) =>
            options.UseInMemoryDatabase("Tareas"));      

            services.AddTransient<ITareaService, TareaService>();

            return services;
        }
    }
}
