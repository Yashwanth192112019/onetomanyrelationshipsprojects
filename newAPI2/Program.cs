using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using newAPI2.Models;
using newAPI2.Repository;
using newAPI2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt => { opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ibird, birdservice>();
builder.Services.AddScoped<ianimal, animalservice>();
builder.Services.AddDbContext<context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
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
