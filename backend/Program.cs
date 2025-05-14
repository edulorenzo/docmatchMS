var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// TODO: Add services and middleware

app.MapGet("/", () => "Welcome to docmatchMS backend!");

app.Run();