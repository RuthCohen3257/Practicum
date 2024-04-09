using EmployeeSystem.API.Mapping;
using EmployeeSystem.Core;
using EmployeeSystem.Core.Repositories;
using EmployeeSystem.Core.Services;
using EmployeeSystem.Data;
using EmployeeSystem.Data.Repositories;
using EmployeeSystem.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IPositionForEmployeeService, PositionForEmployeeService>();
builder.Services.AddScoped<IPositionService, PositionService>();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(PostModelsMappingProfile));
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

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
