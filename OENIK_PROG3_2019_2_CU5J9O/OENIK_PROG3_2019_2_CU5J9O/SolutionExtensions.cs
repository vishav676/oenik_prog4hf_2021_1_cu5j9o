namespace OENIK_PROG3_2020_2_CU5J9O
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class contain static method to display the content.
    /// </summary>
    public static class SolutionExtensions
    {
        /// <summary>
        /// This method will get the list and will display the content.
        /// </summary>
        /// <typeparam name="T">List of type T.</typeparam>
        /// <param name="input">List.</param>
        public static void ToConsole<T>(this IEnumerable<T> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

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
