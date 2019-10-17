using System;
using System.Threading.Tasks;

namespace ConsoleAsync
{
    class Program
    {

        // <= 7.0
        //static void Main(string[] args) 
        //    => MainAsync(args).GetAwaiter().GetResult();
        
        static async Task MainAsync(string[] args)
        {
            await Console.Out.WriteLineAsync("Hello World!");
        }
    }
}
