using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4a
{
    class InvoiceApplication
    {
        static void Main(string[] args)
        {
            // Initialize an array of Invoice objects
            Invoice[] invoices = new Invoice[8];

            // Generates elements of Invoice array
            invoices[0] = new Invoice(83, "Electric sander", 7, 57.98M);
            invoices[1] = new Invoice(24, "Power saw", 18, 99.99M);
            invoices[2] = new Invoice(7, "Sledge hammer", 11, 21.50M);
            invoices[3] = new Invoice(77, "Hammer", 76, 11.99M);
            invoices[4] = new Invoice(39, "Lawn mower", 3, 79.50M);
            invoices[5] = new Invoice(68, "Screwdriver", 106, 6.99M);
            invoices[6] = new Invoice(56, "Jig saw", 21, 11.00M);
            invoices[7] = new Invoice(3, "Wrench", 34, 7.50M);

            // a. Use LINQ to sort the Invoice objects by PartDescription
            var partDescriptionSort =
                from parts in invoices
                orderby parts.PartDescription
                select parts;

            Console.WriteLine("Invoices sorted by PartDescription");
            foreach(var i in partDescriptionSort)
                Console.WriteLine(i.ToString());

            // b. Use LINQ to sort the Invoice objects by price
            var priceSort =
                from parts in invoices
                orderby parts.Price
                select parts;

            Console.WriteLine("\nInvoices sorted by price");
            foreach (var i in priceSort)
                Console.WriteLine(i.ToString());

            // c. Use LINQ to select the PartDescription and Quantity 
            // and sort the results by Quantity
            var quantitySort =
                from parts in invoices
                orderby parts.Quantity
                select new { parts.PartDescription, parts.Quantity };

            Console.WriteLine("\nSelected PartDescription and Quantity, sorted by quantity");
            foreach (var i in quantitySort)
                Console.WriteLine(i.ToString());

            // d. Use LINQ to select from each Invoice the PartDescription 
            // and the value of the Invoice
            var invoiceTotalSortedByValue =
                from parts in invoices
                let invoiceTotal = (parts.Quantity * parts.Price)
                orderby invoiceTotal
                select new { parts.PartDescription, invoiceTotal };

            Console.WriteLine("\nSelected PartDescription and value, sorted by value");
            foreach (var i in invoiceTotalSortedByValue)
                Console.WriteLine(i.ToString());
            
            // e. Using the results of the LINQ query in Part d, select the 
            // InvoiceTotals in the range $200 to $500.
            var invoiceTotalBetween200to500 =
                from parts in invoiceTotalSortedByValue
                where parts.invoiceTotal > 200.00M && parts.invoiceTotal < 500.00M
                orderby parts.invoiceTotal
                select new { parts.PartDescription, parts.invoiceTotal };

            Console.WriteLine("\nSelected InvoiceTotals in the range of $200 to $500");
            foreach (var i in invoiceTotalBetween200to500)
                Console.WriteLine(i.ToString());

        }
    }
}
