using System;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class EmailConfirmation
    {
        public string Email { get; set; }
        public string Hash_Code { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Expiration_Date { get; set; }

        public EmailConfirmation(string email, string hash, DateTime creation, DateTime expiration)
        {
            Email = email;
            Hash_Code = hash;
            Creation_Date = creation;
            Expiration_Date = expiration;
        }

        public EmailConfirmation()
        {
        }
    }
}
