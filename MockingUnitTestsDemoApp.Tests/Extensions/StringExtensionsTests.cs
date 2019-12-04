using MockingUnitTestsDemoApp.Impl.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MockingUnitTestsDemoApp.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Test Case", "test case")]
        [InlineData("TeSt CaSe", "tEsT cAsE")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void StringExtensions_CIEquals_TrueCases(string first, string second)
        {
            var result = first.CIEquals(second);
            Assert.True(result);
        }

        [Theory]
        [InlineData("Test Case", "test case ")]
        [InlineData("TeSt CaSe", "tEsT cAsE 2")]
        [InlineData("Test Case", null)]
        [InlineData("", "Test Case")]
        public void StringExtensions_CIEquals_FalseCases(string first, string second)
        {
            var result = first.CIEquals(second);
            Assert.False(result);
        }
    }
}
