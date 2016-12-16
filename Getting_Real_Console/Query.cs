using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Getting_Real_Console
{
    class Query
    {
        public string connectionString { get; set; }
        public string ProductName { get; set; }
        
        public void QueryMethod(string ColumnName, string TableName)
        {
            decodeConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("Select " + ColumnName + " From " + TableName, con);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            int id = reader.GetInt32(1);
                            ProductName = reader.GetString(0);
                            Console.WriteLine(id + ". " + ProductName);
                        }
                    }

                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal void decodeConnectionString()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\Key.txt");
            byte[] data = Convert.FromBase64String(file.ReadLine());
            string decodedString = Encoding.UTF8.GetString(data);
            connectionString = decodedString;
            file.Close();
        }

        internal void CreateUser(string createName, string createLastName, string createPhoneNR, string createAddress, string createUsername, string createPassword)
        {
            decodeConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("prc_CreateUser",con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@FirstName", createUsername);
                    cmd2.Parameters.Add("@LastName", createLastName);
                    cmd2.Parameters.Add("@Phone", createPhoneNR);
                    cmd2.Parameters.Add("@AddressInfo", createAddress);
                    cmd2.Parameters.Add("@username", createUsername);
                    cmd2.Parameters.Add("Cli_Password", createPassword);
                    cmd2.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("Account Created! Try logging in!");
                    con.Close();
                }
            }
        }

        internal void LogUserIn(string username, string password)
        {
            decodeConnectionString();
            bool loggedin = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("Select username,Cli_Password from Client", con);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Layout print = new Layout();
                        while (reader.Read())
                        {
                            
                            if (username == reader["username"].ToString() && password == reader["Cli_Password"].ToString())
                            {
                                Console.WriteLine("TRUE");
                                loggedin = true;
                            } 
                            if (loggedin)
                            {
                                Console.WriteLine("Correct!");
                                print.GetWelcomeScreen();
                                string ReadKey = Console.ReadLine();
                                print.GetProduct(int.Parse(ReadKey));
                            }
                            
                        }
                        Console.WriteLine("Incorrect Password! Try again!");
                        
                        print.CheckLoginOrCreate(1);
                    }

                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex);
                }
                finally
                {
                    
                    con.Close();
                }
            }
        }
    }
}
