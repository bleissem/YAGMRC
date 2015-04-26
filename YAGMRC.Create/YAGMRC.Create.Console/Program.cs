using System;
using YAGMRC.Core.ViewModel;
using YAGMRC.GoogleStorage;

namespace YAGMRC.Create.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Enter your google name:");
            string name = Console.ReadLine();

            var service = GoogleService.GetInstance().Service(name);


            GoogleDriveStorage googleDriveStorage = new GoogleDriveStorage(name);

            MainViewModel mvm = new MainViewModel(googleDriveStorage);

            //mvm.CreateGame.Execute.Execute(new CreateGameViewModel.CreateGameParam()
            //    {
                     

            //    });
        }
    }
}