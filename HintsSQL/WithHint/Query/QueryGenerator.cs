using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.Sql;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Sql.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Ralms.EntityFrameworkCore.Extensions.With.Query;

namespace Ralms.EntityFrameworkCore.Extensions
{
    public class QueryGenerator : SqlServerQuerySqlGenerator
    {
        public QueryGenerator(
            QuerySqlGeneratorDependencies dependencies,
            SelectExpression selectExpression,
            bool rowNumberPagingEnabled)
            : base(dependencies, selectExpression, rowNumberPagingEnabled)
        { 
        }

        public override Expression VisitTable(TableExpression tableExpression)
        {
            var table =  tableExpression as TableExpressionExtension;

            var visitTable = base.VisitTable(table);

            if (!string.IsNullOrWhiteSpace(table.Hint))
            {
                Sql.Append($" WITH ({table.Hint}) ");
            }
            
            return visitTable;
        } 
    }
}
