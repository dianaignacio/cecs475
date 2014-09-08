// Fig. 12.15: PayableInterfaceTest.cs
// Tests interface IPayable with disparate classes.
using System;
public class PayableInterfaceTest
{
   public static void Main( string[] args )
   {
       IPayable[] payableObjects = new IPayable[8];
       payableObjects[0] = new SalariedEmployee("John", "Smith", "111-11-1111", 700M);
       payableObjects[1] = new SalariedEmployee("Antonio", "Smith", "555-55-5555", 800M);
       payableObjects[2] = new SalariedEmployee("Victor", "Smith", "444-44-4444", 600M);
       payableObjects[3] = new HourlyEmployee("Karen", "Price", "222-22-2222", 16.75M, 40M);
       payableObjects[4] = new HourlyEmployee("Ruben", "Zamora", "666-66-6666", 20.00M, 40M);
       payableObjects[5] = new CommissionEmployee("Sue", "Jones", "333-33-3333", 10000M, .06M);
       payableObjects[6] = new BasePlusCommissionEmployee("Bob", "Lewis", "777-77-7777", 5000M, .04M, 300M);
       payableObjects[7] = new BasePlusCommissionEmployee("Lee", "Duarte", "888-88-888", 5000M, .04M, 300M);

      Console.WriteLine(
         "Invoices and Employees processed polymorphically:\n" );

      // generically process each element in array payableObjects
      foreach ( var currentPayable in payableObjects )
      {
         // output currentPayable and its appropriate payment amount
         Console.WriteLine( "payment due {0}: {1:C}\n", 
            currentPayable, currentPayable.GetPaymentAmount() );
      } // end foreach
   } // end Main
} // end class PayableInterfaceTest

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/