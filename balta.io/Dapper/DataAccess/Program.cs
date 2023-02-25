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

                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Title}");
                }
            }
        }
    }
}