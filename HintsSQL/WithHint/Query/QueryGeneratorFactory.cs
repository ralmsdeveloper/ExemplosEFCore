using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.Sql;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace Ralms.EntityFrameworkCore.Extensions
{
    public class QueryGeneratorFactory : QuerySqlGeneratorFactoryBase
    {
        private readonly ISqlServerOptions _sqlServerOptions;
        public QueryGeneratorFactory(
           QuerySqlGeneratorDependencies dependencies,
           ISqlServerOptions sqlServerOptions)
            : base(dependencies)
        {
            _sqlServerOptions = sqlServerOptions;
        }

        public override IQuerySqlGenerator CreateDefault(SelectExpression selectExpression)
            => new QueryGenerator(
                Dependencies,
                selectExpression,
                _sqlServerOptions.RowNumberPagingEnabled);
    }
}
