using System.Collections.Generic;
using LanguageExt;

namespace EmprendeUCR_WebApplication.Domain.Core.ValueObjects
{

    /// <summary>
    /// Represents a value object with a string that has a size limit and cannot be null or empty.
    /// </summary>
    public class RequiredString : ValueObject
    {
        public const int MaxLength = 1000;

        public string Value { get; }

        private RequiredString(string value)
        {
            Value = value;
        }

        // for EFCore
        private RequiredString()
        {
            Value = null!;
        }

        public static Validation<ValidationError, RequiredString> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();

            if (value.Length > MaxLength)
                return new TooLong(MaxLength);

            return new RequiredString(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public abstract record ValidationError;
        public record IsNullOrWhitespace : ValidationError;
        public record TooLong(int MaxLength) : ValidationError;
    }
}