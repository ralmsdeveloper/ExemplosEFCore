using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.Sql;
using Ralms.EntityFrameworkCore.Extensions;
using Ralms.EntityFrameworkCore.Extensions.With;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RalmsServiceCollectionExtensions
    {
        public static IServiceCollection AddRalmsExtensions(this IServiceCollection services)
        {
            return services
                .AddSingleton<IQuerySqlGeneratorFactory, QueryGeneratorFactory>()
                .AddScoped<IQueryCompilationContextFactory, RalmsCompilationQueryableFactory>()
                .AddScoped<IEntityQueryableExpressionVisitorFactory, RalmsEntityQueryableExpressionVisitorFactory>();
        }
    }
}
