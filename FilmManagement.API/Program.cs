using FilmManagement.Application;
using FilmManagement.Application.Exceptions.Extensions;
using FilmManagement.Application.Pipelines.Validation;
using FilmManagement.Infrastructure;
using FilmManagement.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);


//AddNewtonsoftJson ==> [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] attributesini kullanan alanlarda etkili olmas�n� sa�lar.
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Default exception'� devre d��� b�rak�r.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Film Management API", Version = "v1" });

    // JWT Bearer Authentication i�in Swagger ayarlar�
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "A�a��daki metin kutusuna 'Bearer' [bo�luk] ve ard�ndan ge�erli token'�n�z� girin.\r\n\r\n�rnek: \"Bearer 12345abcdef\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// CORS policy ekleme
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

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

//app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

// Middleware'de CORS kullan�m�
app.UseCors("MyOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
