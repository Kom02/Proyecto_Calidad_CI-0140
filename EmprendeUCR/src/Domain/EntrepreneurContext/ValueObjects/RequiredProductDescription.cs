using EmprendeUCR.Domain.Core.ValueObjects;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.Entrepreneurs.ValueObjects
{
    public class RequiredProductDescription : ValueObject
    {
        public const int MaxLength = 1000;

        public string Value { get; }

        private RequiredProductDescription(string value)
        {
            Value = value;
        }

        // for EFCore
        private RequiredProductDescription()
        {
            Value = null!;
        }

        public static Validation<ValidationError, RequiredProductDescription> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();

            if (value.Length > MaxLength)
                return new TooLong(MaxLength);

            return new RequiredProductDescription(value);
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
