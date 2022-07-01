using Lucap.Repositories.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets("c7dd08bf-554c-4650-a39e-a7a86d031c1a");
}

// Add services to the container.
//builder.Configuration.AddUserSecrets()
var cs = builder.Configuration["LucapDBConnectionString"];
Console.WriteLine(cs);
builder.Services.AddDbContext<LucapDBContext>(options => options.UseNpgsql(cs));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
