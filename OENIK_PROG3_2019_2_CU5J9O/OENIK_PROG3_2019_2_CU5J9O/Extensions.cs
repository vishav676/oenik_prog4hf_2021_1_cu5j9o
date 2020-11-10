namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> input)
        {
            Console.WriteLine("****BEGIN****");
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("**END**");
            Console.ReadLine();
        }
    }
}
