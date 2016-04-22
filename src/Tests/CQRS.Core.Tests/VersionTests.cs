using System;
using Xunit;

namespace CQRS.Core.Tests
{
    public class VersionTests
    {
        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(-1, -2, -3)]
        public void ThrowsOnNegativeValues(int major, int minor, int revision)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Version(major, minor, revision));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void ConstructWithAllValues(int major, int minor, int revision)
        {
            var v = new Version(major, minor, revision);

            Assert.Equal(major, v.Major);
            Assert.Equal(minor, v.Minor);
            Assert.Equal(revision, v.Revision);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void ConstructWithMajorMinor(int major, int minor)
        {
            var v = new Version(major, minor);

            Assert.Equal(major, v.Major);
            Assert.Equal(minor, v.Minor);
            Assert.Equal(0, v.Revision);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void ToStringFormatting(int major, int minor, int revision)
        {
            var v = new Version(major, minor, revision);

            Assert.Equal($"{major}.{minor}.{revision}", v.ToString());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 3, 4)]
        [InlineData(1, 2, 3)]
        [InlineData(0, 0, 3)]
        [InlineData(3, 0, 0)]
        [InlineData(999, 999, 9999)]
        public void HashCodeOverload(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major, minor, revision);
            Assert.StrictEqual(v2.GetHashCode(), v1.GetHashCode());
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void EqualOverloadWithNull(int major, int minor, int revision)
        {
            var v = new Version(major, minor, revision);

            Assert.False(v.Equals((object)null));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void EqualsOverload(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = (object)new Version(major, minor, revision);

            Assert.True(v1.Equals(v2));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void EqualOperator(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major, minor, revision);

            Assert.True(v1 == v2);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void NotEqualOperator(int major, int minor, int revision)
        {
            Random r = new Random();
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(r.Next(), r.Next(), r.Next());

            Assert.True(v1 != v2);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void StringImplicit(int major, int minor, int revision)
        {
            var v = new Version(major, minor, revision);

            Assert.Equal($"{major}.{minor}.{revision}", (string)v);
        }



        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void Equatable(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major, minor, revision);

            Assert.True(v1.Equals(v2));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void ComparableGenericEqual(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major, minor, revision);

            Assert.Equal(0, v2.CompareTo(v1));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void ComparableGenericGreaterThan(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major+1, minor, revision);
            Assert.True(v2.CompareTo(v1) > 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor+1, revision);
            Assert.True(v2.CompareTo(v1) > 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor, revision+1);
            Assert.True(v2.CompareTo(v1) > 0);
        }

        [Theory]
        [InlineData(2, 3, 4)]
        [InlineData(1, 2, 3)]
        [InlineData(9, 10, 13)]
        public void ComparableGenericLessThan(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major-1, minor, revision);
            Assert.True(v2.CompareTo(v1) < 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor-1, revision);
            Assert.True(v2.CompareTo(v1) < 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor, revision-1);
            Assert.True(v2.CompareTo(v1) < 0);
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void ComparableEqual(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major, minor, revision);

            Assert.Equal(0, (object)v2.CompareTo(v1));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 0)]
        public void ComparableGreaterThan(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major + 1, minor, revision);
            Assert.True(v2.CompareTo((object)v1) > 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor + 1, revision);
            Assert.True(v2.CompareTo((object)v1) > 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor, revision + 1);
            Assert.True(v2.CompareTo((object)v1) > 0);
        }

        [Theory]
        [InlineData(2, 3, 4)]
        [InlineData(1, 2, 3)]
        [InlineData(9, 10, 13)]
        public void ComparableLessThan(int major, int minor, int revision)
        {
            var v1 = new Version(major, minor, revision);
            var v2 = new Version(major - 1, minor, revision);
            Assert.True(v2.CompareTo((object)v1) < 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor - 1, revision);
            Assert.True(v2.CompareTo((object)v1) < 0);

            v1 = new Version(major, minor, revision);
            v2 = new Version(major, minor, revision - 1);
            Assert.True(v2.CompareTo((object)v1) < 0);
        }
    }
}
