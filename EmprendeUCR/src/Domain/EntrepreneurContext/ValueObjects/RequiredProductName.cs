using EmprendeUCR.Domain.Core.ValueObjects;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.Entrepreneurs.ValueObjects
{
    public class RequiredProductName : ValueObject
    {
        public const int MaxLength = 1000;

        public string Value { get; }

        private RequiredProductName(string value)
        {
            Value = value;
        }

        // for EFCore
        private RequiredProductName()
        {
            Value = null!;
        }

        public static Validation<ValidationError, RequiredProductName> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();

            if (value.Length > MaxLength)
                return new TooLong(MaxLength);

            return new RequiredProductName(value);
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