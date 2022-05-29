using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data.Common;

namespace DiggRestProfil.Infrastructure.Data.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDapperNpgSql(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbConnection>(provider =>
            {
                return new NpgsqlConnection(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
