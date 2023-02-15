using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TrainerContext>(options =>
options.UseInMemoryDatabase("TrainerList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");


app.MapGet("/Trainer/get", async (TrainerContext tc) =>
await tc.trainers.ToListAsync());

app.MapGet("/Trainer/{id}", async (int id, TrainerContext tc) =>
await tc.trainers.FindAsync(id));


app.MapPost("/Trainers", async (Trainer t, TrainerContext tc) =>
{
    tc.trainers.Add(t);
    await tc.SaveChangesAsync();

});


app.MapPut("/trainer/{id}", async (int id, Trainer t, TrainerContext tc) =>
{
    var find = await tc.trainers.FindAsync(id);
    if (find is null) return Results.NotFound();
    find.Name = t.Name;
    find.password = t.password;
    await tc.SaveChangesAsync();
    return Results.NoContent();

});

app.MapDelete("/Trainer{id}", async (int id, TrainerContext trainerContext) =>
{
    if (await trainerContext.trainers.FindAsync(id) is Trainer trainer)
    {
        trainerContext.trainers.Remove(trainer);
        await trainerContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});


app.Run();

class Trainer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string password { get; set; }
}

class TrainerContext : DbContext
{
    public TrainerContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Trainer> trainers { get; set; }
}

