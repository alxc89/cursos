using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess.Models;

namespace DataAccess
{
    class Program
    {

        #region ADO.Net
        /*static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;Integrated Security=true;Trust Server Certificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado!");
                connection.Open();//Abrindo a conexão com o banco

                using (var command = new SqlCommand())
                {
                    //referenciando a conexão aberta, garatindo que está aberta.
                    command.Connection = connection;
                    //Informando o tipo do comando
                    command.CommandType = System.Data.CommandType.Text;
                    //Aqui é utilizando comando sql, ex: select, update, delete e etc...
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    //o command.ExecuteReader é o mesmo que estar utilizando a instância SqlDataReader(), esse SqlDataReader é utilizado,
                    //no Entity e no Dapper, é a forma mais rápida de leitura no banco.
                    //Existe outros Execute, por ex: ExecuteNonQuery() para executar um update ou insert, esse método retorna um inteiro,
                    //ou seja, retorna a quantidade de linha afetada.
                    var reader = command.ExecuteReader();

                    //Para percorrer a linha é utlizado o método Read(), ele é um cursor, só vai para frente, não volta como um enumerador.
                    //Sendo um cursor, não é possível iterar com um foreach.
                    while (reader.Read())
                    {
                        //Utilizando o Console.WriteLine para escrever no console
                        //Para ler cada valor do select acima: SELECT [Id], [Title] FROM [Category]
                        //É utilizado o reader.GetGuid(0), onde cada Get existe uma opção de tipo.
                        //Ex: GetGuid para tipo de dado Guid, GetString para tipo de dado string
                        //Dentro do método de get, é passado a coluna do select.
                        //Ex: a primeira coluna o Id é um Guid, e seu index é o 0, logo ficaria: GetGuid(0)
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }
        }*/
        #endregion

        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;Integrated Security=true;Trust Server Certificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado!");
                //UpdateCategory(connection);
                //ListCategories(connection);
                //CreateCategory(connection);
                //DeleteCategory(connection);
                //CreateManyCategory(connection);
                //ListCategories(connection);
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                ExecuteScalar(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };

            //Nunca concatenar string para evitar sql injection
            //Para o caso do insert abaixo, melhor seria utilizar parâmetros    
            var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @title, 
                    @url, 
                    @summary, 
                    @order, 
                    @description, 
                    @featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            });

            Console.WriteLine($"{rows} - Linhas inseridas");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2023"
            });

            Console.WriteLine($"{rows} - registros atualizadas");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = "DELETE [Category] WHERE [Id] = @Id";
            var rows = connection.Execute(deleteQuery, new
            {
                id = new Guid("a339d9e0-d580-4208-a201-a89958ddb7c1")
            });
            Console.WriteLine($"{rows} registros excluídos");
        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };

            var category2 = new Category()
            {
                Id = Guid.NewGuid(),
                Title = "Categoria Nova",
                Url = "categoria-nova",
                Description = "Categoria Nova",
                Order = 9,
                Summary = "Categoria",
                Featured = true
            };

            //Nunca concatenar string para evitar sql injection
            //Para o caso do insert abaixo, melhor seria utilizar parâmetros    
            var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @title, 
                    @url, 
                    @summary, 
                    @order, 
                    @description, 
                    @featured)";

            var rows = connection.Execute(insertSql, new[]
            {
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Description,
                    category.Order,
                    category.Summary,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Description,
                    category2.Order,
                    category2.Summary,
                    category2.Featured
                }
            });

            Console.WriteLine($"{rows} - Linhas inseridas");
        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "spDeleteStudent";
            var pars = new { StudentID = "0e4000b8-bca8-462d-af77-8cafe34bf983" };
            var affectdRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);
            Console.WriteLine($"{affectdRows} linhas afetadas");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query(procedure, pars, commandType: CommandType.StoredProcedure);

            foreach (var item in courses)
                Console.WriteLine(item.Id);
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category()
            {
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };

            //Nunca concatenar string para evitar sql injection
            //Para o caso do insert abaixo, melhor seria utilizar parâmetros    
            var insertSql = @"
                INSERT INTO 
                    [Category]
                OUTPUT inserted.[Id] 
                VALUES(
                    NEWID(), 
                    @title, 
                    @url, 
                    @summary, 
                    @order, 
                    @description, 
                    @featured)";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"A Categoria inserida foi: {id}");
        }
    }
}