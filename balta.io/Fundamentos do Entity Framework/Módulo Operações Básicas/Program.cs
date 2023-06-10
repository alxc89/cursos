using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                /*var user = new User
                {
                    Name = "Alex",
                    Slug = "alexcosta",
                    Email = "alex@teste.com",
                    Bio = "9x Microsoft MVP",
                    Image = "https://alex.io",
                    PasswordHash = "123433"
                };

                var category = new Category { Name = "Backend", Slug = "backend" };

                var post = new Post
                {
                    Author = user,
                    Category = category,
                    Body = "<p>Hello world</p>",
                    Slug = "comecando-com-ef-core",
                    Summary = "Neste artigo vamos aprender EF core",
                    Title = "Começando com EF Core",
                    LastUpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };

                context.Posts.Add(post);
                context.SaveChanges(); 

                var posts = context
                    .Posts
                    .AsNoTracking()
                    .Where(x => x.AuthorId == 6)
                    .Include(x => x.Author)
                    .Include(x => x.Category)
                    .OrderBy(x => x.LastUpdateDate)
                    .ToList();

                foreach (var post in posts)
                    Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");*/

                var post = context
                    .Posts
                    //.AsNoTracking() Não precisa
                    .Include(x => x.Author)
                    .Include(x => x.Category)
                    .OrderBy(x => x.LastUpdateDate)
                    .FirstOrDefault(); //Pegando o primeiro item

                post.Author.Name = "Teste";
                context.Posts.Update(post);
                context.SaveChanges();
            }
        }
    }
}