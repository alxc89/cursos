using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;Integrated Security=true;Trust Server Certificate=true";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
            ReadUsers(connection);
            //ReadUser();
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var respository = new UserRepository(connection);
            var users = respository.Get();
            foreach (var user in users)
                System.Console.WriteLine(user.Name);
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                System.Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe Alex",
                Email = "alex@teste.com.br",
                Image = "https://",
                Name = "Equipe",
                PasswordHash = "aldkfa�ls",
                Slug = "equipe-alex"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);

                System.Console.WriteLine("Cadastrado");
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe Alex | Joaquim",
                Email = "alex@teste.com.br",
                Image = "https://",
                Name = "Equipe",
                PasswordHash = "aldkfa�ls",
                Slug = "equipe-alex"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);

                System.Console.WriteLine("Alterado com sucesso!");
            }
        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);

                System.Console.WriteLine("Apagado com sucesso!");
            }
        }
    }
}