using EmprendeUCR_WebApplication.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to map the "Order" table and to used as a Order entity.
 */
namespace EmprendeUCR_WebApplication.Domain.OrderContext.Entities
{
    public partial class Order : AggregateRoot
    {
        public DateTime DateAndHourCreation { get; set; }
        public string ClientEmail { get; set; } 
        public string Details { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string EntrepreneurEmail { get; set; }
        public string State { get; set; }
        public string PaymentName { get; set; }

        // To use EF
        public Order() { }
        public Order(DateTime dateAndHourCreation, string clientEmail, 
                string details, string deliveryAddress, DateTime deliveryDate,
                string entrepreneurEmail, string state, string paymentName)
        {
            DateAndHourCreation = dateAndHourCreation;
            ClientEmail = clientEmail;
            Details = details;
            DeliveryAddress = deliveryAddress;
            DeliveryDate = deliveryDate;
            EntrepreneurEmail = entrepreneurEmail;
            State = state;
            PaymentName = paymentName;
        }

        /* Summary: Set the organized list.
         * Parameters: Receives the new organized list.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void setOrganized(List<Organized> organizeds) {
            Organized = organizeds.AsReadOnly();
        }

        /* Summary: Change all the status of the Organized entities, in the 
         *          organized list, to the new status.
         * Parameters: Receives the new status.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void changeGlobalStatus(string newStatus) {
            foreach (var orderLine in Organized)
            {
               orderLine.ChangeStatus(newStatus);
            }
            this.State = newStatus;
        }

        /* Summary: Sort all the orders of a list, according to the 
         *          entrepreneur order, depending of theirs current state.
         * Parameters: Receives a list of Order Objects.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public List<Order> SortEntrepreneurOrders(List<Order> orders)
        {
            orders = orders.Where(order => order.State != "Terminado")
                .OrderByDescending(order => order.State)
                .Concat(orders.Where(order => order.State == "Terminado"))
                .ToList();

            return orders;
        }

        /* Summary: Sort all the orders of a list, according to the client 
         *          order, depending of theirs current state.
         * Parameters: Receives a list of Order Objects.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public List<Order> SortClientOrders(List<Order> orders)
        {
            /*
             Listo para entrega
             En Progreso
             Aceptado
             Pendiente de revisión
             Terminado
             Rechazado
            */
            orders = orders.Where(order => order.State == "Listo para entrega" || order.State == "En progreso")
                .OrderByDescending(order => order.State)
                .Concat(orders.Where(order => order.State == "Aceptado"))
                .Concat(orders.Where(order => order.State == "Pendiente de revision"))
                .Concat(orders.Where(order => order.State == "Terminado"))
                .Concat(orders.Where(order => order.State == "Rechazado"))
                .ToList();

            return orders;
        }

        public void ChangerOrderStatus(string newStatus)
        {
            this.State = newStatus;
            if (newStatus == "Aceptado" || newStatus == "Terminado")
            {
                foreach (var orderLine in Organized)
                {
                    orderLine.ChangeStatus(newStatus);
                }
            }
        }

        public void changeProductStatus(string productStatus, int CodeId, string EntrepreneurEmail , int CategoryId) 
        {
            var product = Organized.FirstOrDefault(p => p.CodeId == CodeId && p.EntrepreneurEmail == EntrepreneurEmail && p.CategoryId == CategoryId);
            product.ChangeStatus(productStatus);
        }

        public List<Order> filterOrders(List<Order> ordersToFilter, string status)
        {
            return ordersToFilter.Where(item => item.State == status).ToList();   
        }


        // Foreign entities
        private readonly List<Organized> _organizedList;
        public IReadOnlyCollection<Organized> Organized;
        public GenericStatus genericStatus { get; set; }
    }
}
