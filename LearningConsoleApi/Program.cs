using System;
using System.Threading.Tasks;

namespace LearningConsoleApi
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Container.Build(args);
              
            }
            catch (Exception)
            {

                Console.WriteLine("Oh no..!");
            }
            Console.ReadLine();
        }
    }
}