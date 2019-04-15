using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Remotion.Linq.Clauses;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Microsoft.EntityFrameworkCore.Query.ResultOperators.Internal
{
    public class WithHintExpressionNode : ResultOperatorExpressionNodeBase
    {
        public static readonly IReadOnlyCollection<MethodInfo> SupportedMethods = new[]
            { RalmsQueryableExtensions.WithHintMethodInfo };

        private readonly ConstantExpression _withHintExpression;

        public WithHintExpressionNode(
            MethodCallExpressionParseInfo parseInfo,
            ConstantExpression withNoLockExpressionExpression)
            : base(parseInfo, null, null)
            => _withHintExpression = withNoLockExpressionExpression;

        protected override ResultOperatorBase CreateResultOperator(ClauseGenerationContext clauseGenerationContext)
            => new WithHintResultOperator((string)_withHintExpression.Value);

        public override Expression Resolve(
            ParameterExpression inputParameter,
            Expression expressionToBeResolved,
            ClauseGenerationContext clauseGenerationContext)
            => Source.Resolve(inputParameter, expressionToBeResolved, clauseGenerationContext);
    }
}
