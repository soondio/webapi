using Microsoft.EntityFrameworkCore;
using WebApplicationLab2.Models1;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod();

    });
});

// Add services to the container.
builder.Services.AddDbContext<CompClubWebContext>();
//builder.Services.AddDbContext<CompClubDbContext>(opt => opt.UseInMemoryDatabase("CompClub"));
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
