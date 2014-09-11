using System;

namespace Lab2
{
    public delegate bool compareEmployeeSSNDescending(Object o1, Object o2);
    class BubbleSort
    {
        public static void sort(Employee[] a, compareEmployeeSSNDescending e)
		{
            int i;
            int j;
            Employee temp;

            for(i = a.Length - 1; i >= 0; i--)
            {
                for(j = 1; j <= i; j++)
                {
                    if (compareEmployeeSSNDescending(a[j-1], a[j]))
                    {
                        temp = (Employee)a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = temp;
                    }
                }
            }
		}

        public static bool greaterThan(int first, int second)
        {
            return first > second;
        }

        public static bool alphabeticalGreaterThan(int first, int second)
        {
            if ((first.ToString()).CompareTo(second.ToString()) < 0)
                return true;

            else
                return false;
        }

        private static bool compareEmployeeSSNDescending(object p1, object p2)
        {
            return true;
        }
    }
}
