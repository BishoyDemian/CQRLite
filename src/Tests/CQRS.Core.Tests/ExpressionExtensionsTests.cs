using System;
using System.Linq.Expressions;
using CQRS.Core.Internal;
using Xunit;

namespace CQRS.Core.Tests
{
    public class ExpressionExtensionsTests
    {
        internal class MyClass
        {
            public MyClass Child { get; set; }

            public MyClass Self()
            {
                return this;
            }
        }

        private object Property1 { get; set; }
        private MyClass Property2 { get; set; }

        private MemberExpression Invoke<T>(Expression<Func<T>> expression)
        {
            return expression.GetRightMostMember();
        }

        [Fact]
        public void SimpleMemberExpression()
        {
            var result = Invoke(() => Property1);
            Assert.NotNull(result);
            Assert.False(result.CanReduce);
        }

        [Fact]
        public void ComplexMemberExpression()
        {
            var result = Invoke(() => Property2.Child.Self().Child);
            Assert.NotNull(result);
            Assert.False(result.CanReduce);
        }

        [Fact]
        public void MethodCallExpression()
        {
            var result = Invoke(() => Invoke(() => Property2.Self()));
            Assert.NotNull(result);
            Assert.False(result.CanReduce);
        }

        [Fact]
        public void UnaryExpression()
        {
            var expr = Expression.TypeAs(Expression.Constant(34, typeof(int)), typeof(int?));
            Assert.NotNull(expr);
        }

    }
}
