using Blog.Models;

namespace Blog
{
    class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Data.BlogDataContext();
            context.Users.Add(new User
            {
                Bio = "9x Microsoft MVP",
                Email = "andre@balta.io",
                Image = "https://balta.io",
                Name = "André Balta",
                PasswordHash = "1234",
                Slug = "ander-balta",
                Github = "balta"
            });
            context.SaveChanges();
            /*var user = context.Users.FirstOrDefault();
            context.Posts.Add(new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Backend",
                    Slug = "backend"
                },
                CreateDate = DateTime.Now.ToUniversalTime(),
                //LastUpdateDate=
                Slug = "meu artigo",
                Summary = "Neste artigo vamos conferir...",
                //Tags=null,
                Title = "Meu artigo",
            });
            context.SaveChanges();*/
        }
    }
}