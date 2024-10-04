using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Login
    {
        
        public void LoginRun()
        {
            string sqlConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GIthub\EducationCenter\EdicationCenter1\EdicationCenter.mdf;Integrated Security=True";
            Console.Write("username:");
            string username = Console.ReadLine();
            Console.Write("password:");
            string password = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();

            string query = "SELECT password FROM Admin WHERE login = @username";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                var result = command.ExecuteScalar();
                
                if (result != null)
                {
                    string storedusername = result.ToString();
                    Console.WriteLine(storedusername);
                    Console.WriteLine(password);
                    if (password == storedusername)
                    {
                        Console.WriteLine("Login successful!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password.");
                    }
                }
                else
                {
                    Console.WriteLine("Username not found.");
                }
            }
        }
        }


    }

