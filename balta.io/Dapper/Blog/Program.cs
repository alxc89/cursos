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

            ReadUsersWithRoles(connection);
            ReadRoles(connection);
            ReadTags(connection);
            //CreateUser(connection);
            //DeleteUser(connection, 1);
            connection.Close();
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var respository = new UserRepository(connection);
            var items = respository.GetWithRoles();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                    Console.WriteLine($"- {role.Name}");
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Email = "teste@balta.io",
                Bio = "bio",
                Image = "imagem",
                Name = "Name",
                PasswordHash = "hash",
                Slug = "slug"
            };
            var respository = new Repository<User>(connection);
            respository.Create(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var respository = new Repository<Role>(connection);
            var items = respository.Get();
            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var respository = new Repository<Tag>(connection);
            var items = respository.Get();
            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }

        public static void DeleteUser(SqlConnection connection, int id)
        {
            var respository = new Repository<User>(connection);
            User item = respository.Get(id);
            try
            {
                respository.Delete(item);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Não foi possível deletar");
            }
        }
        public static void DeleteRole(SqlConnection connection, int id)
        {
            var respository = new Repository<Role>(connection);
            Role item = respository.Get(id);
            try
            {
                respository.Delete(item);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Não foi possível deletar");
            }
        }
        public static void DeleteTag(SqlConnection connection, int id)
        {
            var respository = new Repository<Tag>(connection);
            Tag item = respository.Get(id);
            try
            {
                respository.Delete(item);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Não foi possível deletar");
            }
        }
    }
}