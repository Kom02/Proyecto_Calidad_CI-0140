using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Application.BillContext
{
    interface IBillService
    {
        void createBill(IJSRuntime js, Order order, List<Tuple<int, Product>> products, string entrepreneurName , string clientName);
        byte[] returnBillBytes(IJSRuntime js, Order order, List<Tuple<int, Product>> products, string entrepreneurName, string clientName);
    }
}
