using Lucap.Repositories.Entities;
using Lucap.Services;
using Lucap.Web;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

var LucapAppOrigin = "LucapAppOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: LucapAppOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3001", "https://myapp.onrender.com");
                          //.AllowAnyHeader();
                      });
});

Console.WriteLine(builder.Configuration["GOOGLE_APPLICATION_CREDENTIALS"]);

// Add services to the container.
builder.Services.AddDbContext<LucapDBContext>(options => options.UseNpgsql(builder.Configuration["LucapDBConnectionString"]));

builder.Services.AddLucapServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        //get options from sercets.json
        Server = builder.Configuration["Server"],
        Port = Convert.ToInt32(builder.Configuration["Port"]),
        SenderName = builder.Configuration["SenderName"],
        SenderEmail = builder.Configuration["SenderEmail"],

        // can be optional with no authentication 
        Account = builder.Configuration["Account"],
        Password = builder.Configuration["Password"],
        // enable ssl or tls
        Security = true
    });
});
builder.Services.AddOptions();
builder.Services.AddScoped<EmailManager>();
Console.WriteLine("GoogleCredentialsFilePath = " + builder.Configuration.GetSection("GoogleCredentials"));
//builder.Services.Configure<GoogleStorageManagerOptions>(builder.Configuration.GetSection("GoogleCredentialsFilePath"));
//builder.Services.AddScoped<GoogleStorageManager>();
builder.Services.AddGoogleStorageService(builder.Configuration.GetSection("GoogleCredentials"));

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
