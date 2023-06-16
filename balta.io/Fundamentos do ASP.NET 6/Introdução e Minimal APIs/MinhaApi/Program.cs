var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Ok("Hello world");
});

app.MapGet("/{nome}", (string nome) =>
{
    return Results.Ok($"Olá {nome}!");
});

app.MapPost("/post", (User user) =>
{
    return Results.Ok(user);
});

app.Run();

public class User
{
    public int Id { get; set; }
    public string? Nome { get; set; }
}