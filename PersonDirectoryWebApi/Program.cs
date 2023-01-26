using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.DbContexts;
using System.Globalization;
using Serilog;
using System.Reflection;
using PersonDirectoryWebApi.Middleware;
using PersonDirectoryWebApi.Repositories.Abstraction.IRepositories;
using PersonDirectoryWebApi.Repositories.Implementation.Repositories;

// configuring serilog logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.xml", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// configuring that program use serialog logger instead of built-in loggers
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(options =>
                {
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    options.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en-US");
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersonApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPersonInfoRepository, PersonInfoRepository>();
builder.Services.AddScoped<IRelatedPersonsInfoRepository, RelatedPersonsInfoRepository>();
builder.Services.AddScoped<IPhoneNumbersInfoRepository, PhoneNumbersInfoRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(x => { x.OperationFilter<AcceptLanguageHeaderFilter>(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.UseMiddleware<ExtractAcceptLanguageMiddleware>();
});

app.UseHttpsRedirection();

app.UseMiddleware<ErrorLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
