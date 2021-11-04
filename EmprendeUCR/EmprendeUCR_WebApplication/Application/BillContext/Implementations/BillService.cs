using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Infrastructure.BillContext;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Application.BillContext.Implementations
{
    public class BillService : IBillService
    {
        private readonly IPdfCreation _pdfCreation;

        public BillService(IPdfCreation pdfCreation)
        {
            _pdfCreation = pdfCreation;
        }

        /*
          Summary: Method dedicated to create the pdf with the billing information. 
          Parameters: Method recieves an Order object as parameter, the names of both the client and the entrepreneur
                      and a list with the products and its prices.
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void createBill(IJSRuntime js, Order order, List<Tuple<int, Product>> products, string entrepreneurName, string clientName)
        {
            js.InvokeVoidAsync("jsSaveAsFile",
                                "Factura_Orden.pdf",
                                Convert.ToBase64String(_pdfCreation.Generate(js,order, products, entrepreneurName, clientName)));
        }

        /*
          Summary: Method to generate an array of bytes containing the order's info
                   in PDF format. To be used when sending the bill to customer.
          Parameters:  The same as the function above, with the same purpose.
          Return: An array of bytes, containing the bill in PDF.
          Exceptions: There aren't known exceptions
         */
        public byte[] returnBillBytes(IJSRuntime js, Order order, List<Tuple<int, Product>> products, string entrepreneurName, string clientName) 
        {
          return _pdfCreation.Generate(js, order, products, entrepreneurName, clientName);
        }
    }
}
