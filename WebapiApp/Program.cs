using Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Services.Abstraction;
using Services.Implemetation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddTransient<DbContext, AppDbContext>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);



// Add services to the container.

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
