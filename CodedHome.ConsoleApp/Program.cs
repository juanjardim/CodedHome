using System;
using CodeHome.Data;

namespace CodedHome.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Database...");

            var context = new DataContext();
            context.Database.Initialize(true);

            Console.WriteLine("Done...");
            Console.ReadLine();
        }
    }
}
