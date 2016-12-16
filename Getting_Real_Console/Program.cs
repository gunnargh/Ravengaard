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
            Console.WriteLine("New to Ravengaard or regular customer?");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create Account");
            string ReadKey = Console.ReadLine();
            print.CheckLoginOrCreate(int.Parse(ReadKey));
           
            Console.ReadLine();
            
        }

    }
}
