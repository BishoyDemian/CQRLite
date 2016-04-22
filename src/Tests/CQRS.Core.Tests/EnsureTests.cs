using System;
using CQRS.Core.Internal;
using Xunit;

namespace CQRS.Core.Tests
{
    public class EnsureTests
    {
        [Theory]
        [InlineData((object)null)]
        [InlineData((string)null)]
        public void ThrowsOnNullValues(object obj)
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(() => obj));
        }

        [Theory]
        [InlineData("")]
        [InlineData(12)]
        public void DoesNotThrowOnNonNullValues(object obj)
        {
            Ensure.NotNull(() => obj);
            Assert.True(true);
        }

        [Theory]
        [InlineData(-1,0,2)]
        [InlineData(0,2,3)]
        [InlineData(4,2,3)]
        public void ThrowsOutsideRange(int val, int min, int max)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Range(() => val, min, max));
        }

        [Theory]
        [InlineData(1,0,2)]
        [InlineData(2,2,3)]
        [InlineData(3,2,3)]
        public void DoesNotThrowWithinRange(int val, int min, int max)
        {
            Ensure.Range(() => val, min, max);
            Assert.True(true);
        }

    }
}
