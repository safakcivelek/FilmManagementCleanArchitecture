using FilmManagement.Application;
using FilmManagement.Application.Features.Films.Rules;
using FilmManagement.Persistence;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AddNewtonsoftJson ==> [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] attributesini kullanan alanlarda etkili olmasýný saðlar.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<FilmBusinessRules>(); // burayý registera geçir.

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
