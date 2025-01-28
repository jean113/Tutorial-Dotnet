using api.Data;
using Api.Handlers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(cnnStr); });
builder.Services.AddTransient<ITodoHandler, TodoHandler>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{ 
    app.UseSwagger(); 
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1")); 
}


app.UseHttpsRedirection(); 
app.UseAuthorization();
app.MapControllers();


app.Run();
