using FluentAssertions;
using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain.Core.ValueObjects
{
    public class RequiredStringTests
    {
        [Fact]
        public void TryCreateEmptyStringShouldReturnValidationError()
        {
            // arrange
            var input = string.Empty;

            // act
            var result = RequiredString.TryCreate(input);

            // assert
            result.IsFail.Should().BeTrue();
            result.Fail().Should().Be(new RequiredString.IsNullOrWhitespace());
        }

        [Fact]
        public void TryCreateNullStringShouldReturnValidationError()
        {
            // arrange
            string input = null;

            // act
            var result = RequiredString.TryCreate(input);

            // assert
            result.IsSuccess.Should().BeFalse();
            result.Fail().Should().Be(new RequiredString.IsNullOrWhitespace());
        }


        [Fact]
        public void TryCreateShortStringShouldReturnRequiredString()
        {
            // arrange
            var input = "short string";

            // act
            var result = RequiredString.TryCreate(input);

            // assert
            result.IsSuccess.Should().BeTrue();
            result.Success().Value.Should().Be(input);
        }

        [Fact]
        public void TryCreateStringOfMaxLengthShouldReturnRequiredString()
        {


            // arrange
            var input = new string('a', RequiredString.MaxLength);

            // act
            var result = RequiredString.TryCreate(input);

            // assert
            result.IsSuccess.Should().BeTrue();
            result.Success().Value.Should().Be(input);
        }

        [Fact]
        public void TryCreateLongStringShouldReturnValidationError()
        {
            // arrange
            var input = new string('a', RequiredString.MaxLength + 1);

            // act
            var result = RequiredString.TryCreate(input);

            // assert
            result.IsSuccess.Should().BeFalse();
            result.Fail().Should().Be(new RequiredString.TooLong(RequiredString.MaxLength));
        }

        [Fact]
        public void ToStringShouldReturnValue()
        {
            // arrange
            var input = "short string";
            var result = RequiredString.TryCreate(input);

            // act
            var toString = result.Success().ToString();

            // assert
            toString.Should().Be(input);
        }

        [Fact]
        public void ToRequiredStringsWithSameValueAreEqual()
        {
            // arrange
            var input = "short string";
            var result1 = RequiredString.TryCreate(input);
            var result2 = RequiredString.TryCreate(input);

            // act
            var requiredString1 = result1.Success();
            var requiredString2 = result2.Success();

            // assert
            requiredString1.Should().Be(requiredString2);
        }
    }
}