using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Create.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your google name:");
            string name = Console.ReadLine();

            var service = YAGMRC.Create.Google.GoogleService.GetInstance().Service(name);

        }
    }
}
