using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using System.IO;

namespace EmprendeUCR_WebApplication.Infrastructure.BillContext.Implementations
{
    public class PdfCreation : IPdfCreation
    {
        /*
          Summary: Method dedicated to stablish the parameters of the pdf file, and the creation of the pdf object.
          Parameters: Method recieves an Order object as parameter, the names of both the client and the entrepreneur
                      and a list with the products and its prices.
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public byte[] Generate(IJSRuntime js, Order order, List<Tuple<int, Product>> products, string entrepreneurName, string clientName)
        {
            var memoryStream = new MemoryStream();

            // Marge in centimeter, then I convert with .ToDpi()
            float margeLeft = 1.5f;
            float margeRight = 1.5f;
            float margeTop = 1.0f;
            float margeBottom = 1.0f;

            Document pdf = new Document(
                                    PageSize.A4,
                                    margeLeft.ToDpi(),
                                    margeRight.ToDpi(),
                                    margeTop.ToDpi(),
                                    margeBottom.ToDpi()
                                   );

            pdf.AddTitle("Blazor-PDF");
            pdf.AddAuthor("Christophe Peugnet");
            pdf.AddCreationDate();
            pdf.AddKeywords("blazor");
            pdf.AddSubject("Create a pdf file with iText");

            PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);
            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
            var labelHeader = new Chunk("Factura de su orden", fontStyle);
            HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
            {
                BackgroundColor = new BaseColor(20, 93, 162),
                Alignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER
            };
            pdf.Header = header;

            var labelFooter = new Chunk("Page", fontStyle);
            HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), true)
            {
                Border = Rectangle.NO_BORDER,
                Alignment = Element.ALIGN_RIGHT
            };
            pdf.Footer = footer;

            pdf.Open();

            PageTable(pdf, writer, order, products, clientName, entrepreneurName);

            pdf.Close();

            return memoryStream.ToArray();
        }

        /*
          Summary: Method dedicated to fill the contest of the pdf file. It calls for the createSections and createTable methods.
          Parameters: Method recieves a pdf object, a pdfwriter, order object as parameter, the names of both the client and the entrepreneur
                      and a list with the products and its prices.
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        private void PageTable(Document pdf, PdfWriter writer, Order order, List<Tuple<int,
                               Product>> products, string entrepreneurName, string clientName)
        {
            var newLine = new Paragraph("Fecha de facturación: " + DateTime.Now.ToString("MM/dd/yyyy"), new Font(Font.HELVETICA, 10, Font.BOLD));
            pdf.Add(newLine);

            createSections(pdf, writer, order, products, entrepreneurName, clientName , newLine);

            Table datatable = new Table(4);  
            createTable(datatable,products,newLine,pdf);      
        }

        /*
          Summary: Method dedicated to the section with the billing information. It uses the library method of Add to add each paragraph
                    to the pdf object.
          Parameters: Method recieves a pdf object, a pdfwriter, order object as parameter, the names of both the client and the entrepreneur
                      a list with the products and its prices, and a Paragraph.
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        private static void createSections(Document pdf, PdfWriter writer, Order order, List<Tuple<int, Product>> products,
                                           string entrepreneurName, string clientName, Paragraph newLine)
        {
            newLine = new Paragraph("Correo del emprendedor: " + order.EntrepreneurEmail, new Font(Font.HELVETICA, 10, Font.BOLD));
            pdf.Add(newLine);
            newLine = new Paragraph("Nombre del emprendedor: " + entrepreneurName, new Font(Font.HELVETICA, 10, Font.BOLD));
            pdf.Add(newLine);

            newLine = new Paragraph("Correo del cliente: " + order.ClientEmail, new Font(Font.HELVETICA, 10, Font.BOLD));
            pdf.Add(newLine);
            newLine = new Paragraph("Nombre del cliente: " + clientName, new Font(Font.HELVETICA, 10, Font.BOLD));
            pdf.Add(newLine);

            newLine = new Paragraph("Metodo de pago: " + order.PaymentName, new Font(Font.HELVETICA, 10, Font.BOLD));
            pdf.Add(newLine);
        }

        /*
          Summary: Method dedicated to create a table in wich the products are gonna be displayed. 
          Parameters: Method recieves a pdf object, an object Table, a list with the products and its prices, and a Paragraph.
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        private static void createTable ( Table datatable , List<Tuple<int,Product>> products , Paragraph newLine , Document pdf)
        {
            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 20, 10, 10, 10 };

            datatable.Widths = headerwidths;
            datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;

            datatable.AddCell("Detalle");
            datatable.AddCell("Cantidad");
            datatable.AddCell("Precio");
            datatable.AddCell("Precio Total");

            int totalPriceLine = 0;
            int totalPrice = 0;
            int price = 0;
            int quantity = 0;

            foreach (var productLine in products)
            {
                price = productLine.Item2.currentPrice;
                quantity = productLine.Item1;
                totalPriceLine = price * quantity;
                totalPrice += totalPriceLine;
                datatable.AddCell(productLine.Item2.ProductName);
                datatable.AddCell(quantity.ToString());
                datatable.AddCell(price.ToString());
                datatable.AddCell(totalPriceLine.ToString());
            }

            pdf.Add(datatable);

            newLine = new Paragraph("Monto total de factura: " + totalPrice, new Font(Font.HELVETICA, 15, Font.BOLD));
            pdf.Add(newLine);
        }
    }
}
