using Microsoft.EntityFrameworkCore;
using PayFlow.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(Options =>
    Options.SwaggerEndpoint("/openapi/v1.json", "PayFlow API"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
