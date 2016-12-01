using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real_Console
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            Layout print = new Layout();
            print.GetWelcomeScreen();
            string ReadKey = Console.ReadLine();
            print.GetProduct(int.Parse(ReadKey));
            Console.ReadLine();
            
        }

    }
}
