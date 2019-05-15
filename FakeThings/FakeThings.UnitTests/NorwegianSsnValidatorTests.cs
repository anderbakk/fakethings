using FluentAssertions;
using System;
using Xunit;

namespace FakeThings.UnitTests
{
    public class NorwegianSsnValidatorTests
    {
        [Fact]
        public void IsValid_NullValue_ShouldBeFalse()
        {
            var result = new NorwegianSsnValidator().IsValid(null);
            result.Should().BeFalse();
        }
        [Fact]
        public void IsValid_InvalidLength_ShouldBeFalse()
        {
            var result = new NorwegianSsnValidator().IsValid("9");
            result.Should().BeFalse();
        }
        [Fact]
        public void IsValid_InvalidCharacter_ShouldBeFalse()
        {
            var result = new NorwegianSsnValidator().IsValid("x0123456789");
            result.Should().BeFalse();
        }

    }
}
