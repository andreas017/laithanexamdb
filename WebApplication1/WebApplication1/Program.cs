using FluentValidation;
using Lib.Interface;
using Lib.Services;
using Lib.Services.RequestService;
using Lib.Services.Validators;
using Lib.Settings;
using Microsoft.EntityFrameworkCore;
using Training.Sql.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCinemaHandler).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<NewCinemaValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCinemaValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("CinemaDB");


builder.Services.Configure<MinioOptions>(builder.Configuration.GetSection("MinIO"));
builder.Services.AddSingleton<IStorageProvider, MinioService>();
builder.Services.AddDbContext<CinemaDbContext>(dbcontextBuilder =>
{
    dbcontextBuilder.UseNpgsql(connString).UseSnakeCaseNamingConvention();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
