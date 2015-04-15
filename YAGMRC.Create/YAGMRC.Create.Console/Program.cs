using System;
using YAGMRC.Create.GoogleStorage;

namespace YAGMRC.Create.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter your google name:");
            string name = Console.ReadLine();

            var service = GoogleService.GetInstance().Service(name);
        }
    }
}