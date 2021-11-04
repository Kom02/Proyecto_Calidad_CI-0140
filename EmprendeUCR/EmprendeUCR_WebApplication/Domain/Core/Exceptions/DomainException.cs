using System;

namespace EmprendeUCR_WebApplication.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string? message) : base(message)
        {
        }
    }
}