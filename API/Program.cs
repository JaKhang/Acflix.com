using Application.DI;
using Hangfire;
using Infrastructure.DI;
using Infrastructure.Persistence.Config;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Minio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;
builder.Services.InfrastructureServices(configuration);
builder.Services.ApplicationServices(configuration);
builder.Services.AddControllers();
builder.Services.AddMinio(configureClient => configureClient
        .WithEndpoint("localhost:9000")
        .WithCredentials(configuration.GetSection("S3").GetValue<string>("AccessKey"), configuration.GetSection("S3").GetValue<string>("SecretKey"))
        .WithSSL(false)
        .Build()
);
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue; // Unlimited size
});
builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = long.MaxValue); // Allows for even larger files

builder.Services.AddHangfire(cf =>
    cf.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseDefaultTypeSerializer()
        .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));
builder.Services.AddHangfireServer();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
