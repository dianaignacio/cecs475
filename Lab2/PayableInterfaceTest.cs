// Fig. 12.15: PayableInterfaceTest.cs
// Tests interface IPayable with disparate classes.
using System;
namespace Lab2
{
    public class PayableInterfaceTest
    {
        public static void Main(string[] args)
        {
            int menuOption;
            IPayable[] payableObjects = new IPayable[8];
            payableObjects[0] = new SalariedEmployee("John", "Smith", "111-11-1111", 700M);
            payableObjects[1] = new SalariedEmployee("Antonio", "Smith", "555-55-5555", 800M);
            payableObjects[2] = new SalariedEmployee("Victor", "Smith", "444-44-4444", 600M);
            payableObjects[3] = new HourlyEmployee("Karen", "Price", "222-22-2222", 16.75M, 40M);
            payableObjects[4] = new HourlyEmployee("Ruben", "Zamora", "666-66-6666", 20.00M, 40M);
            payableObjects[5] = new CommissionEmployee("Sue", "Jones", "333-33-3333", 10000M, .06M);
            payableObjects[6] = new BasePlusCommissionEmployee("Bob", "Lewis", "777-77-7777", 5000M, .04M, 300M);
            payableObjects[7] = new BasePlusCommissionEmployee("Lee", "Duarte", "888-88-8888", 5000M, .04M, 300M);

            do
            {
                menuOption = getMenuOption();

                switch (menuOption)
                {
                    case 1: // Sort by social security number in ascending order
                        // Implemented through sorting algorithm using delegate
                        sortSocialSecurityNumberAscend(payableObjects);
					    break;

                    case 2: // Sort by last name in descending order
                        // Implemented through IComparable interface
                        sortLastNameDescending(payableObjects);
                        break;
                    case 3: // Sort by pay amount in ascending  order
                        // Implemented through IComparer interface
                        sortPayAmountAscending(payableObjects);
                        break;
                    case 4: // Sort by pay amount in descending order
                        // Implemented through IComparer interface
                        sortPayAmountDescending(payableObjects);
                        break;
                    case 5: // Exit the program
                        Console.WriteLine("Program teminated normally.");
                        break;
                    default: // Invalid menu option
                        Console.WriteLine("Invalid menu option. Please re-enter.");
                        break;
                }	// end of switch statement
            } while (menuOption != 5);

            // generically process each element in array payableObjects
            foreach (var currentPayable in payableObjects)
            {
                // output currentPayable and its appropriate payment amount
                Console.WriteLine("payment due {0}: {1:C}\n",
                   currentPayable, currentPayable.GetPaymentAmount());
            } // end foreach
        } // end Main

        public static int getMenuOption()
        {
            int menuOption;
            Console.WriteLine("\nPlease select a sorting option");
            Console.WriteLine("1. Sort by social security number in ascending order");
            Console.WriteLine("2. Sort by last name in descending order");
            Console.WriteLine("3. Sort by pay amount in ascending  order");
            Console.WriteLine("4. Sort by pay amount in descending order");
            Console.WriteLine("5. Exit the program.");

            menuOption = optionCheck("\nEnter a menu option: ", 1, 5);

            return menuOption;
        }  // end method getMenuOption

        public static int optionCheck(string message, int min, int max)
        {
            Console.Write(message);
            string line = Console.ReadLine();
            int number;
            while (!(int.TryParse(line, out number) && min <= number && number < max))
            {
                Console.Write("\nInvalid entry. Please retry: ");
                line = Console.ReadLine();
            }
            return number;
        }

        public static void sortSocialSecurityNumberAscend(IPayable[] people)
        {
            Employee[] employeeArray = new Employee[8];
            for (int i = 0; i < people.Length; i++)
            {
                employeeArray[i] = (Employee)people[i];
            }

            //BubbleSort.sort(employeeArray, Employee.CompareStringAscending);
            foreach (var person in employeeArray)
            {
                Console.WriteLine(person + "\n");
            }
        } // end sortSocialSecurityNumberAscend

        public static void sortLastNameDescending(IPayable[] people)
        {
            Array.Sort(people);
            Console.WriteLine("\nArray - Sorted by Last Name (Descending - IComparable)\n");

            foreach (var currentPayable in people)
                Console.WriteLine(currentPayable);
        }

        public static void sortPayAmountAscending(IPayable[] people)
        {
            Array.Sort(people, Employee.sortPayAmountAscending());
            Console.WriteLine("\nArray - Sorted by Last Name (Descending - IComparable)\n");

            foreach (var currentPayable in people)
                Console.WriteLine(currentPayable);
        }

        public static void sortPayAmountDescending(IPayable[] people)
        {
            Array.Sort(people, Employee.sortPayAmountDescending());
            Console.WriteLine("\nArray - Sorted by Last Name (Descending - IComparable)\n");

            foreach (var currentPayable in people)
                Console.WriteLine(currentPayable);
        }

    } // end class PayableInterfaceTest
}
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