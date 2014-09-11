using System;
namespace Lab2
{
    public delegate bool ComparisonHandler(Employee e1, Employee e2);
    class BubbleSort
    {
        public static void sort(Employee[] a, ComparisonHandler e)
		{
            int i;
            int j;
            object temp;

            for(i = a.Length - 1; i >= 0; i--)
            {
                for(j = 1; j <= i; j++)
                {
                    if (e(a[j-1], a[j]))
                    {
                        temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = (Employee)temp;
                    }
                }
            }
		}

        public static bool compareEmployeeSsnAscending(Employee p1, Employee p2)
        {
            int first, second;
            first = TryToParse(p1.SocialSecurityNumber);
            second = TryToParse(p2.SocialSecurityNumber);
            return first > second;
        }

        private static int TryToParse(string value)
        {
            int number;
            value = value.Replace("-", "");
            bool result = Int32.TryParse(value, out number);
            return number;
        }

    }
}
