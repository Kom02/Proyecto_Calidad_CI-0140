using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;

/*Se agrega el servicio de confiramción de email para ser utilizado en el .razor*/
namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Email_ConfirmationService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Email_ConfirmationService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public IList<Email_Confirmation> getEmailConfirmations()
        {
            return _context.Email_Confirmation.ToList();
        }

        public void addEmailConfirmation(Email_Confirmation confirmation)
        {
            _context.Email_Confirmation.Add(confirmation);
            _context.SaveChanges();
        }

        public void updateEmailConfirmation(Email_Confirmation confirmation)
        {
            Email_Confirmation email_confirmation = _context.Email_Confirmation.FirstOrDefault(c => c.Email.Equals(confirmation.Email));
            if (email_confirmation != null)
            {
                email_confirmation.Email = confirmation.Email;
                email_confirmation.Hash_Code = confirmation.Hash_Code;
                email_confirmation.Creation_Date = confirmation.Creation_Date;
                email_confirmation.Expiration_Date = confirmation.Expiration_Date;
                _context.Update(email_confirmation);
                _context.SaveChanges();
            }
        }

        public Email_Confirmation getEmailConfirmation(string hash_code)
        {
            Email_Confirmation email_confirmation = _context.Email_Confirmation.FirstOrDefault(c => c.Hash_Code.Equals(hash_code));
            return email_confirmation;
        }

        public Email_Confirmation getEmailConfirmationEmail(string email)
        {
            Email_Confirmation email_confirmation = _context.Email_Confirmation.FirstOrDefault(c => c.Email.Equals(email));
            return email_confirmation;
        }

        /*Returns TRUE if the email is expired*/
        public bool verifyExpirationDate(Email_Confirmation email) 
        {
            bool verify = false;
            DateTime fecha = DateTime.Now;
            if (email.Expiration_Date < fecha) 
            {
                verify = true;
            }
            return verify;
        }
    }
}
