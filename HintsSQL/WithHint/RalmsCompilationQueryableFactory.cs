using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.ResultOperators.Internal;

namespace Microsoft.EntityFrameworkCore.Query
{
    public class RalmsCompilationQueryableFactory : QueryCompilationContextFactory
    {
        public RalmsCompilationQueryableFactory(
            QueryCompilationContextDependencies dependencies,
            RelationalQueryCompilationContextDependencies relationalDependencies)
            : base(dependencies)
        {
            relationalDependencies
                .NodeTypeProviderFactory
                .RegisterMethods(WithHintExpressionNode.SupportedMethods, typeof(WithHintExpressionNode)); 
        }

        public override QueryCompilationContext Create(bool async)
            => async
                ? new RelationalQueryCompilationContext(
                    Dependencies,
                    new AsyncLinqOperatorProvider(),
                    new AsyncQueryMethodProvider(),
                    TrackQueryResults)
                : new RelationalQueryCompilationContext(
                    Dependencies,
                    new LinqOperatorProvider(),
                    new QueryMethodProvider(),
                    TrackQueryResults);
    }
}
