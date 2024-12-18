using Geometrie.BLL;
using Geometrie.DAL;
using Geometrie.DTO;
using Geometrie.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//pour ajouter un service dans le conteneur d'injection de dépendances
builder.Services.AddSingleton<IPoint_Service>(new Point_Service(new GeometrieContext()));

builder.Services.AddSingleton<List<Cercle>>();

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
