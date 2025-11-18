using DataAccess.Context;
using DataAccess.Repositories;
using Interfaces.IManager;
using Interfaces.IRepository;
using Interfaces.IService;
using Microsoft.EntityFrameworkCore;
using Models;
using Managers;
using Services;


var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register Generic DI
builder.Services.AddScoped(typeof(IStudentRepository<>), typeof(StudentRepository<>));
builder.Services.AddScoped(typeof(IStudentManager<>), typeof(StudentManager<>));
builder.Services.AddScoped(typeof(IStudentService<>), typeof(StudentService<>));

// Build app
var app = builder.Build();

// Enable Swagger UI in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();