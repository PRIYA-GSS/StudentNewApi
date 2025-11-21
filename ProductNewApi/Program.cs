using DataAccess.Context;
using DataAccess.Repositories;
using Interfaces.IManager;
using Interfaces.IRepository;
using Interfaces.IService;
using Managers;
using Microsoft.EntityFrameworkCore;
using Services;
using StudentNewApi.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
    });

// Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register Generic DI
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IStudentManager), typeof(StudentManager));
builder.Services.AddScoped(typeof(IStudentService), typeof(StudentService));

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