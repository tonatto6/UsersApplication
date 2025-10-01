using UsersApplication.Repository;
using UsersApplication.Repository.Interfaces;
using UsersApplication.Services;
using UsersApplication.Services.Interfaces;

namespace UsersApplication.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersServices, UsersServices>();

            return services;
        }
    }
}
