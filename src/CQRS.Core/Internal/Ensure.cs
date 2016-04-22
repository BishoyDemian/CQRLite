using System;
using System.Linq.Expressions;

namespace CQRS.Core.Internal
{
    internal static class Ensure
    {
        public static void NotNull<T>(Expression<Func<T>> expression) where T : class
        {
            var memberExpression = expression.GetRightMostMember();
            var name = memberExpression.ToPath();
            var value = expression.Compile().Invoke();
            if (value == null)
                throw new ArgumentNullException(name);
        }

        public static void Range<T>(Expression<Func<T>> expression, T min, T max) where T : IComparable
        {
            var memberExpression = expression.GetRightMostMember();
            var name = memberExpression.ToPath();
            var value = expression.Compile().Invoke();
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new ArgumentOutOfRangeException(name);
        }
    }
}
