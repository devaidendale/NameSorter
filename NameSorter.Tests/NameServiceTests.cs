using System;
using System.Collections.Generic;
using NameSorter.Services;
using NameSorter.Models;
using Xunit;

namespace NameSorter.Tests
{
    public class NameServiceTests
    {
        [Fact]
        public void SortNames_ShouldSortByLastnameThenFirstname ()
        {
            // Arrange
            var TestNameService = new NameService(new DataFileService("Mock", "Mock"));
            var TestNames = new List<Name>(new Name[]
                {
                    new Name("A A Z"),
                    new Name("A A"),
                    new Name("Z Z"),
                    new Name("Z A A"),
                    new Name("A A A A"),
                });
            var expected = new List<Name>(new Name[]
                {
                    new Name("A A"),
                    new Name("A A A A"),
                    new Name("Z A A"),
                    new Name("A A Z"),
                    new Name("Z Z"),
                });

            // Act
            var actual = TestNames;
            TestNameService.sortNames(actual);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void ConvertDataToNames_ShouldBeEqual ()
        {
            // Arrange
            const string INPUT = "Plain Simple Garak";
            var TestNameService = new NameService(new DataFileService("Mock", "Mock"));
            var TestData = new string[] { INPUT };
            var expected = new List<Name>(new Name[] { new Name(INPUT) });

            // Act
            var actual = new List<Name>();
            TestNameService.convertDataToNames(TestData, actual);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNamesToData_ShouldBeEqual ()
        {
            // Arrange
            const string INPUT = "Plain Simple Garak";
            var TestNameService = new NameService(new DataFileService("Mock", "Mock"));
            var TestNames = new List<Name>(new Name[] { new Name(INPUT) });
            var expected = new string[] { INPUT };

            // Act
            var actual = new string[1];
            TestNameService.convertNamesToData(TestNames, actual);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
