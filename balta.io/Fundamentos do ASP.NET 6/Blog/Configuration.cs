namespace Blog;

public static class Configuration
{
    //TOKEN - JWT
    public static string JwtKey { get; set; } = "OWFjY2EyYzAtMjA1Ny00MzY2LWEyNzctNzlmYjQyMWIxNGUy";
    public static string ApiKeyName = "api_key";
    public static string ApiKey = "curso_api_IlTevUM/z0ey3NwCV/unWg==";
    public static SmtpConfiguration Smtp = new();
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}