using MagadiApp.Services.ProductAPI;
using MagadiApp.Services.ProductAPI.DbContexts;
using MagadiApp.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Seeder>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", builder =>

        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("https://localhost:7219")
    );
});



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("FrontEndClient");

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();

seeder.Seed();

app.UseHttpsRedirection();

// add method to generate swagger JSON
app.UseSwagger();
app.UseSwaggerUI(c =>
{                       //default path to file and name of api docs
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MagadiApp.ProductAPI");
});
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
