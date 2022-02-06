/* ================================================
 * @author     David Volm aka VOLMINATOR aka daXXog
 * @date       Sat Feb  5 17:32:12 CST 2022
 * @school     UWSP
 * @class      CIS 340
 * @section    01
 * @assignment 01
 * @professor  Hardeep Kaur Dhalla
 * @licence    MIT
 * ===============================================*/

using System;


namespace HardwareStore {
    class InvoiceTest {
        static void Main(string[] args) {
            // some formatting lambdas
            Action<Invoice> printPartNumber    = _invoice => System.Console.WriteLine($"Part number: {_invoice.PartNumber}");
            Action<Invoice> printDescription   = _invoice => System.Console.WriteLine($"Description: {_invoice.PartDescription}");
            Action<Invoice> printQuantity      = _invoice => System.Console.WriteLine($"Quantity: {_invoice.Quantity}");
            Action<Invoice> printPrice         = _invoice => System.Console.WriteLine($"Price: ${_invoice.Price}");
            Action<Invoice> printInvoiceAmount = _invoice => System.Console.WriteLine($"Invoice amount: ${_invoice.GetInvoiceAmount()}");


            // test 01
            Invoice invoice1 = new Invoice(
                partNumber: "1234",
                partDescription: "Hammer",
                quantity: 2,
                price: 14.95m
            );
            System.Console.WriteLine("Original invoice information");  //- Original invoice information
            printPartNumber(invoice1);                                 //- Part number: 1234
            printDescription(invoice1);                                //- Description: Hammer
            printQuantity(invoice1);                                   //- Quantity: 2
            printPrice(invoice1);                                      //- Price: $14.95
            printInvoiceAmount(invoice1);                              //- Invoice amount: $29.90
            System.Console.WriteLine();                                //- 


            // test 02
            invoice1.PartNumber      = "001234";
            invoice1.PartDescription = "Yellow Hammer";
            invoice1.Quantity        = 3;
            invoice1.Price           = 19.49m;

            System.Console.WriteLine("Updated invoice information");   //- Updated invoice information
            printPartNumber(invoice1);                                 //- Part number: 001234
            printDescription(invoice1);                                //- Description: Yellow Hammer
            printQuantity(invoice1);                                   //- Quantity: 3
            printPrice(invoice1);                                      //- Price: $19.49
            printInvoiceAmount(invoice1);                              //- Invoice amount: $58.47
            System.Console.WriteLine();                                //- 


            // test 03
            Invoice invoice2 = new Invoice(
                partNumber: "5678",
                partDescription: "PaintBrush"
            );
            System.Console.WriteLine("Original invoice information");  //- Original invoice information
            printPartNumber(invoice2);                                 //- Part number: 5678
            printDescription(invoice2);                                //- Description: PaintBrush
            printQuantity(invoice2);                                   //- Quantity: 0
            printPrice(invoice2);                                      //- Price: $0.00
            printInvoiceAmount(invoice2);                              //- Invoice amount: $0.00
            System.Console.WriteLine();                                //- 


            // test 03
            invoice2.Quantity        = 3;
            invoice2.Price           = 9.49m;

            System.Console.WriteLine("Updated invoice information");   //- Updated invoice information
            printPartNumber(invoice2);                                 //- Part number: 5678
            printDescription(invoice2);                                //- Description: PaintBrush
            printQuantity(invoice2);                                   //- Quantity: 3
            printPrice(invoice2);                                      //- Price: $9.49
            printInvoiceAmount(invoice2);                              //- Invoice amount: $28.47
        }
    }
}
