using Blog.Models;
using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new Data.BlogDataContext();
            //Traking: o entity traz os metadata do banco
            //O traking é utilizado para realizar updates, inserts e deletes.
            //Para select(consulta) não seria necessário esses metadatas
            //Caso a consulta não vai ser alterada, seria recomendado o uso do AsNoTraking
            //Ex:
            /*var post = context.Posts.FirstOrDefault(x => x.Id > 1);//Com o traking
            var posts = context.Posts.AsNoTracking();//Sem o traking
            Console.WriteLine($"Id: {post.Id}");*/

            //Se utilizado assim: .FirstOrDefault(x => x.Id == 2) será retornado um post
            //Se utilizado assim: .FirstOrDefaultAsync(x => x.Id == 2) será retornado uma tarefa conténdo um post
            //Quando é marcado com o sufixo Async, é aplicado um paralelismo, não será aguardado a execução.
            //Criando métodos assincronos.
            //Nesses casos também é utilizado a palavra await antes da chamada
            //Ficando assim: var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == 2);

            /*var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == 2);
            var posts = await GetPostsAsync(context);
            
            foreach (var item in posts)
                Console.WriteLine($"posts: {item.Id}");
            Console.WriteLine("Teste");
            Console.WriteLine($"post: {post.Id}");*/


            //Lazy Loading
            //Por padrão não vai carregar as listas que são de tabelas que são relacionadas
            //Toda vez que você for iterar em algum objeto que esteja como lazy loading,
            //será realizado um select nessa tabela relacionada.

            //Eager Loading
            //Por padrão também não vai carregar as listas de tabelas relacionadas
            //A diferença é que sempre que eu quiser que venha, preciso explicitar isso.
            //Para isso, informo o incluide, ex: context.Posts.Includes(x => x.Tags)
            //Eager Loading é o padrão adotado pelo Entity Framework

            //var post = GetPostsAsync(context, 0, 25);
            //Include e ThenInclude retorna os dados de tabelas relacionadas.
            //Tomar cuidado que vai rolar subselect nas consultas.
            /*var posts = context.Posts
                .Include(x => x.Author)
                    .ThenInclude(x => x.Roles)
                .Include(x => x.Category);*/

            var posts = context.PostWithTagsCounts.ToList();

            foreach (var post in posts)
                Console.WriteLine($"{post.Name}");
        }
        //Retornado dados paginados
        /*public static async Task<IEnumerable<Post>> GetPostsAsync(BlogDataContext context, int skip = 0, int take = 25)
        {
            return await context
                .Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }*/
    }
}