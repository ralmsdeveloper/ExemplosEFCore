using System;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Clauses;
using Remotion.Linq.Clauses.ResultOperators;
using Remotion.Linq.Clauses.StreamedData;

namespace Microsoft.EntityFrameworkCore.Query.ResultOperators.Internal
{
    public class WithHintResultOperator : SequenceTypePreservingResultOperatorBase, IQueryAnnotation
    {
        public WithHintResultOperator(string hint)
        {
            Hint = hint;
        }
        
        public virtual string Hint { get; }
        public virtual IQuerySource QuerySource { get; set; }
        public virtual QueryModel QueryModel { get; set; }
        public override string ToString() => !string.IsNullOrWhiteSpace(Hint) ? $"WITH ({Hint})" : "";
        public override ResultOperatorBase Clone(CloneContext cloneContext)
            => new WithHintResultOperator(Hint);

        public override void TransformExpressions(Func<Expression, Expression> transformation)
        {
        }

        public override StreamedSequence ExecuteInMemory<T>(StreamedSequence input) => input;
    }
}
