using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query;

namespace Microsoft.EntityFrameworkCore
{
    public static class RalmsQueryableExtensions
    {
        #region WithHint
        internal static readonly MethodInfo WithHintMethodInfo
            = typeof(RalmsQueryableExtensions)
                .GetTypeInfo().GetDeclaredMethods(nameof(WithHint))
                .Single();

        public static IQueryable<TEntity> WithHint<TEntity>(
            this IQueryable<TEntity> source,
            [NotParameterized] string hint)
            where TEntity : class
        {
            return source.Provider.CreateQuery<TEntity>(
                Expression.Call(
                    null,
                    WithHintMethodInfo.MakeGenericMethod(typeof(TEntity)),
                    source.Expression,
                    Expression.Constant(hint, typeof(string))));
        }
        #endregion 
    }
}
