using FruityviceAPI.Services.Implementation;
using FruityviceAPI.Services.Interface;
using XTGlobalWebAPI.BusinessLayer.Implementations;
using XTGlobalWebAPI.BusinessLayer.Interfaces;
using XTGlobalWebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMvc(config => config.Filters.Add(typeof(CustomExceptionHandler)));

builder.Services.AddTransient<IFruityviceAPIService, FruityviceAPIService>();
builder.Services.AddTransient<IGetAllFruits, GetAllFruits>();
builder.Services.AddTransient<IRetrieveFruitsByFamily, RetrieveFruitsByFamily>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API");
});

app.Run();
