using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;

namespace EmprendeUCR_WebApplication.Infrastructure.BillContext
{
    public interface IPdfCreation
    {
        public byte[] Generate(IJSRuntime js, Order order, List<Tuple<int, Product>> products, string entrepreneurName, string clientName);
    }
}
