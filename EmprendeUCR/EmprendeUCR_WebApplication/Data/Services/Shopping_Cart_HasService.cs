using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

/*
  Shopping_Cart_HasService : This file contains the necessary class to retrieve
                             information from the Shopping_Cart_Has sql table.
*/
namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Shopping_Cart_HasService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Shopping_Cart_HasService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        /*
            Summary: Method to retrieve the total number of products a given user
                     has on their shopping cart
            Receives: string userEmail, the email that belongs to the logged user,
                      needed to identify all the shopping cart has tuples that
                      represent products added to the user SC.
            Returns: an integer resulting from a method that takes the userEmail.
            What might make this to fail: nothing
        */
        public int GetProductsQuantity(string userEmail)
        {
            return _context.Shopping_Cart_Has.AsNoTracking().Where(sc => sc.Email  == userEmail).Count();
        }

    }
}
