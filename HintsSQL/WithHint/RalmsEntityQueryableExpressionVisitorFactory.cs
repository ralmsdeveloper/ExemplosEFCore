using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Remotion.Linq.Clauses;
using System.Linq.Expressions;

namespace Ralms.EntityFrameworkCore.Extensions.With
{
    public class RalmsEntityQueryableExpressionVisitorFactory : IEntityQueryableExpressionVisitorFactory
    {
        public RalmsEntityQueryableExpressionVisitorFactory(
            RelationalEntityQueryableExpressionVisitorDependencies dependencies)
            => Dependencies = dependencies;

        protected virtual RelationalEntityQueryableExpressionVisitorDependencies Dependencies { get; }

        public virtual ExpressionVisitor Create(
            EntityQueryModelVisitor queryModelVisitor, IQuerySource querySource)
            => new RalmsEntityQueryableExpressionVisitor(
                Dependencies,
                (RelationalQueryModelVisitor)queryModelVisitor,
                querySource);
    }
}