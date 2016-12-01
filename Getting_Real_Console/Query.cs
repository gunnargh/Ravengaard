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
    }
}
