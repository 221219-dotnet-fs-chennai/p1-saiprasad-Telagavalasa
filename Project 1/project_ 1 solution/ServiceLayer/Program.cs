using Bussiness_Logic;
using FluentApi;
using FluentApi.Entities;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
//builder.Services.AddScoped<IFilter,FilterRepo>





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
