using Bussiness_Logic;
using FluentApi;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration.GetConnectionString("SaiDB");
builder.Services.AddDbContext<Project1Context>(options=>options.UseSqlServer(config));

builder.Services.AddScoped<ILogic,Logic>();
builder.Services.AddScoped<IRepo<FluentApi.Entities.Trainer>, EFRepo>();


builder.Services.AddScoped<ISkillLogic, SkillLogic>();
builder.Services.AddScoped<ISkill<FluentApi.Entities.Skill>, SkillRepo>();


builder.Services.AddScoped<ICompanyLogic,CompanyLogic>();
builder.Services.AddScoped<ICompany<FluentApi.Entities.Company>,CompanyRepo>();


builder.Services.AddScoped<IEducationLogic,EducationLogic>();
builder.Services.AddScoped<IEducation<FluentApi.Entities.Education>,EducationRepo>();


builder.Services.AddScoped<IAvailabiityLogic,AvailabilityLogic>();
builder.Services.AddScoped<IAvailability<FluentApi.Entities.Availability>,AvailabilityRepo>();


builder.Services.AddScoped<IFilterLogic,FilterLogic>();
builder.Services.AddScoped<Validation, Validation>();
builder.Services.AddScoped<IFilter<FluentApi.Entities.Trainer>, FilterRepo>();


var Allowpolicy = "AllowPolicy";
builder.Services.AddCors(options => options.AddPolicy(Allowpolicy, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));







var app = builder.Build();
app.UseCors(Allowpolicy);

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
