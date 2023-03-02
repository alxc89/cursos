using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;Integrated Security=true;Trust Server Certificate=true";
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                    System.Console.WriteLine(user.Name);
            }
        }
    }
}