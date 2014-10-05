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

            // Use LINQ to sort the Invoice objects by PartDescription
            var partDescriptionSort =
                from parts in invoices
                orderby parts.PartDescription
                select parts;

            Console.WriteLine("Invoices sorted by PartDescription");
            foreach(var i in partDescriptionSort)
                Console.WriteLine(i.ToString());
        }
    }
}
