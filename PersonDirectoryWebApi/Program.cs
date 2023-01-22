using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.DbContexts;
using PersonDirectoryWebApi.Services.IRepositories;
using PersonDirectoryWebApi.Services.Repositories;
using Serilog;

// configuring serilog logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.xml", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// configuring that program use serialog logger instead of built-in logger
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersonApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPersonInfoRepository, PersonInfoRepository>();
builder.Services.AddScoped<IRelatedPersonsInfoRepository, RelatedPersonsInfoRepository>();
//registring automapper service. AddAutoMapper method allows us to pass through an area of assemblies, it's these assemblies that will automatically get scanned for profiles that contain mapping configurations (it will be in Profile file, which will be used to nicely organize mapping configuration). While registring autoMapper service, we need to state that we want to get the assemblies from the current AppDomain and we call into GetAssemblies on CurrentDomain on AppDomain, which ensure that the current assembly, so the cityinfo assembly will be scanned for profiles.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
