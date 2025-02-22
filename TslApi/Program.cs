using Microsoft.AspNetCore.Authentication.JwtBearer;
using TslApi;
using TslApi.Models;
using TslApi.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Config>(builder.Configuration.GetSection(Config.ConfigRef));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddHostedService<DataRetrievalBackground>();

builder.Services.AddTransient<IDataService, DataService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();//Should use access tokens but time consuming without proper Auth server/log in

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //Dev enrionment Only
    app.UseCors(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapHub<RaceDataHub>("RaceData");

//Add minimal api endpoints if time

app.Run();