using Lucap.Repositories.Models;
using Lucap.Services;
using Microsoft.EntityFrameworkCore;

var LucapAppOrigin = "LucapAppOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: LucapAppOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", "https://myapp.onrender.com");
                      });
});

// Add services to the container.
builder.Services.AddDbContext<LucapDBContext>(options => options.UseNpgsql(builder.Configuration["LucapDBConnectionString"]));

builder.Services.AddLucapServices();

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

app.UseCors(LucapAppOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
