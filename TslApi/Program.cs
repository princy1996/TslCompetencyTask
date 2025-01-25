using TslApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddHostedService<DataRetrievalBackground>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //Dev enrionment Only
    app.UseCors(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
}
app.UseHttpsRedirection();

app.MapHub<RaceDataHub>("RaceData");

app.Run();