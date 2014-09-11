﻿// Fig. 12.4: Employee.cs
// Employee abstract base class.
using System;
using System.Collections;

    public abstract class Employee : IPayable, IComparable
    {

        public static bool compareSSNDescending(Object o1, Object o2)
        {
            bool ascendingString = false;


            return ascendingString;
        }

        // read-only property that gets employee's first name
        public string FirstName { get; private set; }

        // read-only property that gets employee's last name
        public string LastName { get; private set; }

        // read-only property that gets employee's social security number
        public string SocialSecurityNumber { get; private set; }

        // three-parameter constructor
        public Employee(string first, string last, string ssn)
        {
            FirstName = first;
            LastName = last;
            SocialSecurityNumber = ssn;
        } // end three-parameter Employee constructor

        public static bool CompareStringAscending(string firstString, string secondString)
        {
            bool ascendingString = false;

            if (string.Compare(firstString, secondString) > 0)
            {
                ascendingString = true;
            }

            return ascendingString;
        }

        // return string representation of Employee object, using properties
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}",
               FirstName, LastName, SocialSecurityNumber);
        } // end method ToString

        // abstract method overridden by derived classes
        public abstract decimal GetPaymentAmount(); // no implementation here

        // Implement IComparable CompareTo to provide default sort order.
        int IComparable.CompareTo(object obj)
        {
            Employee compared = (Employee)obj;

            if (compared.LastName.Equals(this.LastName))
            {   // If we are equal, check the first name...
                if (this.FirstName.Equals(compared.FirstName))
                {   // If we are equal again, verify the SSN...
                    return String.Compare(this.SocialSecurityNumber, compared.SocialSecurityNumber);
                }
                else
                {
                    return String.Compare(this.FirstName, compared.FirstName);
                }
            }
            else
            {   // Our base case.
                return String.Compare(compared.LastName, this.LastName);
            }
        }

        private class sortPayAmountAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Employee e1 = (Employee)a;
                Employee e2 = (Employee)b;

                if (e1.GetPaymentAmount() > e2.GetPaymentAmount())
                    return 1;

                if (e1.GetPaymentAmount() < e2.GetPaymentAmount())
                    return -1;

                else
                    return 0;
            }
        }
       
        // Method to return IComparer object for sort helper.
        public static IComparer sortPayAmountAscending()
        {
            return (IComparer)new sortPayAmountAscendingHelper();
        }

        private class sortPayAmountDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Employee e1 = (Employee)a;
                Employee e2 = (Employee)b;

                if (e1.GetPaymentAmount() < e2.GetPaymentAmount())
                    return 1;

                if (e1.GetPaymentAmount() > e2.GetPaymentAmount())
                    return -1;

                else
                    return 0;
            }
        }

        private class sortLastNameDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Employee e1 = (Employee)a;
                Employee e2 = (Employee)b;
                return String.Compare(e2.LastName, e1.LastName);
            }
        }


        // Method to return IComparer object for sort helper.
        public static IComparer sortPayAmountDescending()
        {
            return (IComparer)new sortPayAmountDescendingHelper();
        }

        // Method to return IComparer object for sort helper.
        public static IComparer sortLastNameDescending()
        {
            return (IComparer)new sortLastNameDescendingHelper();
        }
    } // end abstract class Employee

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