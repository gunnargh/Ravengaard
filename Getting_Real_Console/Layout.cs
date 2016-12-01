using System;
using System.Data.SqlClient;
using System.Data;

namespace Getting_Real_Console
{
    internal class Layout
    {
        public int ReadKey { get; set; }
        public string Result { get; set; }
        internal void GetWelcomeScreen()
        {
            Console.WriteLine("Welcome To Ravengaard Ring Design system!");
            Console.WriteLine("What do you want to design to day?");
            Query SQL = new Query();
            SQL.QueryMethod("ProductType_Name,ProductType_ID", "ProductType");
            Console.WriteLine("Select what kind of product you want to design: ");

        }

        internal void GetProduct(int key)
        {

            int i = 1;
            Console.WriteLine("You selected " + key);
            switch (key)
            {
                
                case 1:
                    {
                        
                        Console.WriteLine("What do you want to design first?");
                        Console.WriteLine(i++ + ". Rock Type");
                        Console.WriteLine(i++ + ". Rock Holder");
                        Console.WriteLine(i++ + ". Ring Type");
                        Console.WriteLine(i++ + ". Check Cart");
                        Console.WriteLine(i++ + ". Go To Checkout");
                        string ReadKey = Console.ReadLine();
                        BuildQuery selectedRock = new BuildQuery();
                        selectedRock.getRockInfo(int.Parse(ReadKey));

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("What do you want to design first?");
                        Console.WriteLine(i++ + ". Necklace Chain");
                        Console.WriteLine(i++ + ". Necklace Pendant");
                        Console.WriteLine(i++ + ". Necklace Color");
                        Console.WriteLine(i++ + ". Check Cart");
                        Console.WriteLine(i++ + ". Go To Checkout");
                        string ReadKey = Console.ReadLine();
                        break;
                    }
                case 3:
                    break;

            }
        }
    }
}