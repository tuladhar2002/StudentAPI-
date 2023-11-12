using Microsoft.EntityFrameworkCore;
using StudentAPI_Main.Data;
using StudentAPI_Main.Mapping;
using StudentAPI_Main.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI for SQL connection setup
builder.Services.AddDbContext<StudentAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentsAPIConnectionString")));

//DI for SQLRepo where Dbcontext is imported
builder.Services.AddScoped<IStudentRepository, SQLStudentRepository>();

//DI for AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
