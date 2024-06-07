using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<MongoDBSettings>(
//    builder.Configuration.GetSection("MongoDB"));

//builder.Services.AddSingleton<MongoDBService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcomAPI", Version = "v1" });
});




// Configure CORS to allow any traffic
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1"));
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");



// for serving images
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Data")),
    RequestPath = "/Data"
});





//var itemsService = app.Services.GetRequiredService<MongoDBService>();







/////////////////////Catalog

app.MapGet("/api/GetCatalog", () =>
{

    return "lol";//_DBContext.GetCatalog();
})
.WithName("GetCatalog")
.WithOpenApi();

app.MapGet("/api/GetItem/{id}", (int id) =>
{

    return "lol";//_DBContext.GetCatalog();
})
.WithName("GetItem")
.WithOpenApi();

app.MapPost("/api/items", async (ItemDTO item) =>
{
    if (item == null)
    {
        return Results.BadRequest("User is null.");
    }

    await _DBContext.InsertUser(item);

    return Results.Ok(new { message = "User created successfully.", item });
}).WithName("CreateItem")
.WithOpenApi();









///////////////////////
///





app.Run();