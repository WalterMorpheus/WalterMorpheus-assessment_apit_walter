using Microsoft.EntityFrameworkCore;
using Repo.Data;

namespace Displaying_Details.Extensions
{
    public static class ApplicationServiceExtensions
    {
        /*
         * This extends the Services from the program.cs to add any custom service code 
         */
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
              IConfiguration config)
        {
            services.AddDbContext<ClientDbContext>(opt => {
                opt.UseSqlServer(config.GetConnectionString("DbContext"));
            });

            return services;
        }
    }
}
