using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using TrainerEntity;
using TrainerEntity.Entities;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var trainer_config = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<Project1DbContext>(options => options.UseSqlServer(trainer_config));
builder.Services.AddScoped<ILogic, Logic>();

builder.Services.AddScoped<IRepo, Repo>();
//builder.Services.AddScoped<BusinessLogic.Logic>();
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
