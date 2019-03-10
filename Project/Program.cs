using System;
using Project.Common.Core.Classes;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Project.Task.Main();

            task.Run(new ConsoleView());
            
            Console.ReadLine();
        }
    }
}
