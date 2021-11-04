using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

namespace EmprendeUCR_WebApplication.Application.OrderContext
{ 
    // Interface implementation for the OrderService
    interface IOrderService
    {
        // Interface declaration methods for the OrderService 
        Task <List<Order>> GetEntrepreneurOrders(string email);
        Task <List<Order>> GetEntrepreneurAcceptedOrders(string email);
        Task <List<Order>> GetClientOrders(string email);
        List<Tuple<int, Product>> GetProducts(Order order);
        Task <List<Status>> GetOrderStatuses();
        Task SetProductStatuses(Product product, List<Status> statusesList);
        Task <string> getEntrepreneurName(string email);
        Task <List<Order>> sendAnswer(DateTime dateAndHourCreation, string email, bool answer,List<Order> orderToUpdate);
        Task updateOrderStatus(Order order,string newStatus);
        Task updateProductStatus(Order currentOrder, string productStatus, Product productToUpdate);
        public string getStatusColor(string status);
    }
}
