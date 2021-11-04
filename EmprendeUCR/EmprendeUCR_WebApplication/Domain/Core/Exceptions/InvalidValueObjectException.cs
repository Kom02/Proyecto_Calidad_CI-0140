using System;

namespace EmprendeUCR_WebApplication.Domain.Core.Exceptions
{
    public class InvalidValueObjectException : DomainException
    {
        public InvalidValueObjectException(string? message) : base(message)
        {
        }
    }
}