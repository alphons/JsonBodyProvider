using JsonBodyProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddJsonProviders(CorrectLists: true);

var app = builder.Build();

app.MapControllers();
app.Run();
