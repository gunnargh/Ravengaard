using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


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

        internal void CheckLoginOrCreate(int ReadKey)
        {
            
            Query SQL = new Query();
            switch (ReadKey)
            {
                case 1:
                    {
                        Console.WriteLine("Username/Email: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        SQL.LogUserIn(username,password);
                        
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Hi, now fill out the information required to account");
                        Console.WriteLine("Note! Your username will be your email address!");
                        Console.WriteLine("Firstname: ");
                        string createName = Console.ReadLine();
                        Console.WriteLine("Lastname: ");
                        string createLastName = Console.ReadLine();
                        Console.WriteLine("Phone Number: ");
                        string createPhoneNR = Console.ReadLine();
                        Console.WriteLine("Address: ");
                        string createAddress = Console.ReadLine();
                        Console.WriteLine("Email: ");
                        string createUsername = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string createPassword = Console.ReadLine();
                        //byte[] createPassword = Encoding.UTF8.GetBytes(Console.ReadLine());
                        if (createPassword.Length => 8 && Regex.IsMatch(createPassword, @"^[a-zA-Z0-9\_]+$"))
                        {
                            SQL.CreateUser(createName, createLastName, createPhoneNR, createAddress, createUsername, createPassword);
                            CheckLoginOrCreate(1);
                        } else
                        {
                            Console.WriteLine("Password does not match criteria, needs to be at least 8 carachters long and it has to contain numbers!");
                            Console.WriteLine("Lets try this again");
                            CheckLoginOrCreate(2);
                        }
                        
                        
                        break;
                    }
                
            }
        }

       
    }
}