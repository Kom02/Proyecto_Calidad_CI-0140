using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the methods used by queries to take, enter or
 * change data in the EmprendeUCR database, in the context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        /* Summary: Take the data base, in the context of the orders, and 
         *          assigns it to the _dbContext varible to use it in the 
         *          future.
         * Parameters: Receives the data base, in the context of the orders.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public OrderRepository(OrderDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /* Summary: Retrieves all the orders, of a specific entrepreneur, that
         *          are in the state of "Pendiente".
         * Parameters: Receives the entrepreneur's email.
         * Return: A list of orders.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<List<Order>> GetByIdAsync(string email)
        {

            List<Order> orders = await _dbContext.Orders
               .Where(order => order.EntrepreneurEmail == email && order.State == "Pendiente de revision")
               .Include(order => order.Organized)
                    .ThenInclude(Organized => Organized.productService)
                .Include(order => order.Organized)
                    .ThenInclude(Organized => Organized.status)
               .ToListAsync();

            return orders;
        }

        /* Summary: Retrieves all the accepted orders, of a specific 
         *          entrepreneur.
         * Parameters: Receives the entrepreneur's email.
         * Return: A list of orders.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<List<Order>> GetAcceptedOrders(string email)
        {

            List<Order> orders = await _dbContext.Orders
               .Where(order => order.EntrepreneurEmail == email && order.State != "Pendiente de revision" && order.State != "Rechazado")
               .OrderBy(order => order.State)
               .Include(order => order.genericStatus)
               .Include(order => order.Organized)
                    .ThenInclude(Organized => Organized.productService)
                .Include(order => order.Organized)
                    .ThenInclude(Organized => Organized.status)
               .ToListAsync();

            orders = new Order().SortEntrepreneurOrders(orders);

            return orders;
        }

        /* Summary: Retrieves all the orders, of a specific client, that are in
         *          the state of "Rechazado" or "Aceptado".
         * Parameters: Receives the client's email.
         * Return: A list of orders.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<List<Order>> GetClientOrdersAsync(string email)
        {
            List<Order> orders = await _dbContext.Orders
               .Where(order => order.ClientEmail == email)
               .OrderBy(order => order.State)
               .Include(order => order.Organized)
                    .ThenInclude(Organized => Organized.productService)
                .Include(order => order.Organized)
                    .ThenInclude(Organized => Organized.status)
               .ToListAsync();

            orders = new Order().SortClientOrders(orders);

            _dbContext.Database.ExecuteSqlRaw("exec ChangeViewToTrue @p0", parameters : new[] { email } );
            return orders;
        }

        /* Summary: Retrieves all the products of a specific order.
         * Parameters: Receives the order.
         * Return: A list of tuples with the products and their quantity.
         * Exceptions: There aren't known exceptions.
        */
        public List<Tuple<int, Product>> GetProductsAsync(Order order)
        {
            List<Tuple<int, Product>> products = _dbContext.Products
                .Include(product => product.ProductHasStatus)
                .Include(product => product.Organized)
                .Where(product => product.Organized.Any(o => o.DateAndHourCreation == order.DateAndHourCreation &&
                       o.Email == order.ClientEmail && o.CodeId == product.CodeId && o.CategoryId == product.CategoryId &&
                       o.EntrepreneurEmail == product.EntrepreneurEmail))
                .Select(product => new Tuple<int,Product>
                                (product.Organized.Where(o => o.DateAndHourCreation == order.DateAndHourCreation &&
                                 o.Email == order.ClientEmail && o.CodeId == product.CodeId && o.CategoryId == product.CategoryId &&
                                 o.EntrepreneurEmail == product.EntrepreneurEmail).FirstOrDefault().Quantity, product))
                .ToList();

            return products;
        }

        /*
          Summary: Method to get the statuses of the orders in the right order.
          Parameters: Nothing.
          Return: Returns a list of string with the statuses.
          Exceptions: There aren't known exceptions
        */
        public async Task<List<Status>> GetOrderStatuses()
        {
            List<Status> statuses = await _dbContext.Statuses
                .Where(status => status.Name == "Terminado")
                .ToListAsync();

            Status currentStatus;
            while(statuses.First().Name != "Aceptado")
            {
                currentStatus = (await _dbContext.Statuses
                    .Where(status => status.Name == statuses.First().PreviousStateName)
                    .ToListAsync()).First();

                statuses.Insert(0, currentStatus);
            }
            return statuses;
        }

        /*
          Summary: Fill a list of statuses with the personalized statuses of
                   a specific product.
          Parameters: Recieves a Product Object and a List of Status Objects.
          Return: Nothing.
          Exceptions: There aren't known exceptions
        */
        public Task SetProductStatuses(Product product, List<Status> statusesList)
        {
            List<Status> statuses = _dbContext.Statuses
                .Include(status => status.personalizedStatus)
                    .ThenInclude(personalizedStatus => personalizedStatus.ProductHasStatus)
                .Where(status => status.personalizedStatus.ProductHasStatus.Any(productStatus => 
                               productStatus.CodeId == product.CodeId &&
                               productStatus.CategoryId == product.CategoryId &&
                               productStatus.EntrepreneurEmail == product.EntrepreneurEmail))
                .ToList();

            int index = statusesList.FindIndex(status => status.Name == "En progreso");
            statusesList.InsertRange(index+1, statuses);

            return Task.CompletedTask;
        }

        /* Summary: Update a specific order.
         * Parameters: Receives the order.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public async Task orderUpdate(Order OrderToUpdate)
        {
             _dbContext.Update(OrderToUpdate);
            await _dbContext.SaveEntitiesAsync();
        }

        public string defineColor(string status)
        {
            string color = "";
            if (status == "Aceptado")
            {
                color = "softGreen";
            }
            else if (status == "Rechazado")
            {
                color = "red";
            }
            else if (status == "Listo para entrega")
            {
                color = "medIntenseGreen";
            }
            else if (status == "Pendiente de revision")
            {
                color = "yellow";
            }
            else if (status == "Terminado")
            {
                color = "finishedGreen";
            }
            else
            {
                color = "lightMediumGreen";
            }
            return color;
        }


        /* Summary: Retrieves all the orders, of a specific entrepreneur, that
         * are in the state of "Finalizado".
         * Parameters: Receives the entrepreneur's email.
         * Return: A list of orders.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<List<Order>> GetEntreprenurFinalizedOrders(string email)
        {
            List<Order> orders = await _dbContext.Orders
           .Where(order => order.EntrepreneurEmail == email && order.State == "Terminado")
           .Include(order => order.Organized)
                .ThenInclude(Organized => Organized.productService)
            .Include(order => order.Organized)
                .ThenInclude(Organized => Organized.status)
           .ToListAsync();

            return orders;
        }
        
        public async Task<string> GetEntreprenurName(string email)
        {
            //string name = await _dbContext.Database.ExecuteSqlRaw("exec ChangeViewToTrue @p0", parameters: new[] { email });
            //string name = await _dbContext.Database.ExecuteSqlRaw("SELECT dbo.GetUserName (@p0", parameters: new[] { email });

            string retval = _dbContext.Database.ExecuteSqlRaw("SELECT dbo.GetUserName('" + email + "')").ToString();

            return retval;
        }
        
    }
}
