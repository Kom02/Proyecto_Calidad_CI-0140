using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.Repositories;

namespace EmprendeUCR_WebApplication.Application.OrderContext.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOfferRepository _offerRepositoy;
        /*
          Summary: Constructor.
          Parameters:IOrderRepository orderRepository.
          Exceptions: There aren't known exceptions
        */
        public OrderService(IOrderRepository orderRepository, IOfferRepository offerRepository )
        {
            _orderRepository = orderRepository;
            _offerRepositoy = offerRepository;
        }

        /*
          Summary: Method to get the orders of an entrepreneur related to an email.
          Parameters: Method gets string email related to an user.
          Return: An order asociated to an email
          Exceptions: There aren't known exceptions
        */
        public async Task<List<Order>> GetEntrepreneurOrders(string email)
        {
            return await _orderRepository.GetByIdAsync(email);
        }

        /*
          Summary: Method to get the accepted orders of an entrepreneur related
                   to an email.
          Parameters: Method gets string email related to an user.
          Return: A list of orders asociated to an email
          Exceptions: There aren't known exceptions
        */
        public async Task<List<Order>> GetEntrepreneurAcceptedOrders(string email)
        {
            return await _orderRepository.GetAcceptedOrders(email);
        }

        /*
           Summary: Method to get the finalized orders of a client related to an email.
           Parameters: Method gets string email related to an user.
           Return: An order asociated to an email
           Exceptions: There aren't known exceptions
         */
        public async Task<List<Order>> GetEntrepreneurFinalizedOrders(string email)
        {
            return await _orderRepository.GetEntreprenurFinalizedOrders(email);
        }

        /*
          Summary: Method to get the orders of a client related to an email.
          Parameters: Method gets string email related to an user.
          Return: Returns a list of finalized orders related to an email
          Exceptions: There aren't known exceptions
        */
        public async Task<List<Order>> GetClientOrders(string email)
        {
            return await _orderRepository.GetClientOrdersAsync(email);
        }

        /*
          Summary: Method to get the products related to an order.
          Parameters: Method receives an order object.
          Return: Returns a list of products related to related to an order.
          Exceptions: There aren't known exceptions
        */
        public List<Tuple<int, Product>> GetProducts(Order order)
        {
            DateTime dateOrder = order.DateAndHourCreation;
            List<Offer> offers =  _offerRepositoy.getOffersToOrder(dateOrder);
            var orders = _orderRepository.GetProductsAsync(order);
            foreach (var product in orders)
            {
                product.Item2.getCurrentPrice(offers);
            }
            return orders;
        }

        /*
          Summary: Method to get the statuses of the orders.
          Parameters: Nothing.
          Return: Returns a list of string with the statuses.
          Exceptions: There aren't known exceptions
        */
        public async Task<List<Status>> GetOrderStatuses()
        {
            return await _orderRepository.GetOrderStatuses();
        }
        /*
         Summary: get the color set for a state 
         Parameters: status
         Return: string with the color set for the state 
         Exceptions: There aren't known exceptions
       */
        public string getStatusColor(string status)
        {
            return _orderRepository.defineColor(status);
        }

        /*
          Summary: Set a list of statuses with the statuses of a specific
                   product.
          Parameters: Recieves a Product Object and a List of Status Objects.
          Return: Nothing.
          Exceptions: There aren't known exceptions
        */
        public async Task SetProductStatuses(Product product, List<Status> statusesList)
        {
            await _orderRepository.SetProductStatuses(product, statusesList);
            //return Task.CompletedTask;
        }

        /*
          Summary: Method to send an answer from an entrepreneur to a client.
          Parameters: Method receives a date and hour, an email, the answer to be sent and the order to update.
          Return: Returns a List of orders
          Exceptions: There aren't known exceptions
        */
        public async Task<List<Order>>sendAnswer(DateTime dateAndHourCreation, string email, bool answer, List<Order> ordersToUpdate)
        {
            Order orderToUpdate = ordersToUpdate.FirstOrDefault(order => order.DateAndHourCreation == dateAndHourCreation && order.ClientEmail == email);
            orderToUpdate.changeGlobalStatus(answer ? "Aceptado" : "Rechazado" );
            await _orderRepository.orderUpdate(orderToUpdate);
            ordersToUpdate.RemoveAll(r => r.DateAndHourCreation == dateAndHourCreation && r.ClientEmail == email);
            return  ordersToUpdate;
        }

        /*
          Summary: Method to get the entrepreneur name.
          Parameters: Method receives an email.
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public async Task<string> getEntrepreneurName(string email)
        {
            return await _orderRepository.GetEntreprenurName(email);
        }
        /*
          Summary: update the status of an order.
          Parameters: order to update
                      the new status for the order
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public async Task updateOrderStatus(Order order,string newStatus) {
            order.ChangerOrderStatus(newStatus);
            await _orderRepository.orderUpdate(order);
        }
        /*
          Summary: update the status of an order.
          Parameters: Order to update
                      The new status for the order
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public async Task updateProductStatus(Order currentOrder, string productStatus, Product productToUpdate) {
            currentOrder.changeProductStatus(productStatus, productToUpdate.CodeId, productToUpdate.EntrepreneurEmail , productToUpdate.CategoryId);
            await _orderRepository.orderUpdate(currentOrder);
        }
    }
}
