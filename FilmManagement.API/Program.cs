using FilmManagement.Application;
using FilmManagement.Application.Exceptions.Extensions;
using FilmManagement.Application.Pipelines.Validation;
using FilmManagement.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);


//AddNewtonsoftJson ==> [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] attributesini kullanan alanlarda etkili olmasýný saðlar.
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();

// Default exception'ý devre dýþý býrakýr.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.DocExpansion(DocExpansion.None);
    });
    app.UseDeveloperExceptionPage();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
