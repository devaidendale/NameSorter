using System;
using NameSorter.Models;
using Xunit;

namespace NameSorter.Tests
{
    public class NameTests
    {
        [Theory]
        [InlineData("Frank Herbert", "Frank Herbert")]
        [InlineData("Clive Staples Lewis", "Clive Staples Lewis")]
        [InlineData("John Ronald Reuel Tolkien", "John Ronald Reuel Tolkien")]
        public void ToString_ShouldReturnFullname (string input, string expected)
        {
            // Arrange
            var TestName = new Name(input);

            // Act
            var actual = TestName.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_EmptyNameShouldThrowException ()
        {
            // Arrange
            Name TestName;
            const string TESTNAME_INPUT = "";

            // Act, Assert
            Assert.Throws<Exception>(() => TestName = new Name(TESTNAME_INPUT));
        }

        [Fact]
        public void Constructor_OneNameShouldThrowException ()
        {
            // Arrange
            Name TestName;
            const string TESTNAME_INPUT = "Aesop";

            // Act, Assert
            Assert.Throws<Exception>(() => TestName = new Name(TESTNAME_INPUT));
        }

        [Fact]
        public void Constructor_FiveNamesShouldThrowException ()
        {
            // Arrange
            Name TestName;
            const string TESTNAME_INPUT = "This Name Should Not Work";

            // Act, Assert
            Assert.Throws<Exception>(() => TestName = new Name(TESTNAME_INPUT));
        }

        [Theory]
        [InlineData("B B", "A A", 1)]
        [InlineData("A B", "B A", 1)]
        [InlineData("B A", "A B", -1)]
        [InlineData("B B", "C A B", -1)]
        [InlineData("B B", "Z Z Z A", 1)]
        public void CompareTo_ShouldCompareLastnameFirst (string first, string second, int expected)
        {
            // Arrange
            var TestName_first = new Name(first);
            var TestName_second = new Name(second);

            // Act
            var actual = TestName_first.CompareTo(TestName_second);

            // Assert
            Assert.True(actual == expected);
        }

        [Theory]
        [InlineData("A A", "A A", true)]
        [InlineData("Z Z", "Z Z", true)]
        [InlineData("A A A", "A A a", false)]
        [InlineData("A A A A", "A A A A", true)]
        [InlineData("Z Z Z Z", "Z Z Z Z", true)]
        public void Equals_ShouldCheckEquality (string first, string second, bool expected)
        {
            // Arrange
            var TestName_first = new Name(first);
            var TestName_second = new Name(second);

            // Act
            var actual = TestName_first.Equals(TestName_second);

            // Assert
            Assert.True(actual == expected);
        }
    }
}
