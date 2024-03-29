using Microsoft.EntityFrameworkCore;
using TaskManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(Options => Options.UseSqlServer("Server=localhost;Database=TaskManager;Trusted_Connection=true;" + "TrustServerCertificate=True"));

builder.Services.AddCors(options =>
{
options.AddPolicy("AllowAll",
    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
