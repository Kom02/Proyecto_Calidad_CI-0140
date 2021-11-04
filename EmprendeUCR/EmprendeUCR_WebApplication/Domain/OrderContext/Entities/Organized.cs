using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to map the "Organized" table and to used as a Organized
 * entity.
 */
namespace EmprendeUCR_WebApplication.Domain.OrderContext.Entities
{
    public partial class Organized
    {
        public int CodeId { get; set; }
        public string EntrepreneurEmail { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateAndHourCreation { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfChange { get; set; }

        public Organized() { }
        public Organized(int codeId, string entrepreneurEmail, int categoryId,
                DateTime dateAndHourCreation, string email, string name,
                int quantity, DateTime dateOfChange, Order _order)
        {

            CodeId = codeId;
            EntrepreneurEmail = entrepreneurEmail;
            CategoryId = categoryId;
            DateAndHourCreation = dateAndHourCreation;
            Email = email;
            Name = name;
            Quantity = quantity;
            DateOfChange = dateOfChange;
            order = _order;
        }

        /* Summary: Change the state name of the attribute Name.
         * Parameters: Receives the new state name.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void ChangeStatus(string newStatus){
            Name = newStatus;
        } 

        // Foreign entities
        public Order order { get; set; }
        public Status status { get; set; }
        public ProductService productService { get; set; }
    }
}
