using MinimalAPI_Net6_Playground.Data.Models;
using MinimalAPI_Net6_Playground.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products/{id}", (Guid id, IProductRepository productRepository) => { return productRepository.Get(id); });

app.MapPost("/products",
    (Product product, IProductRepository productRepository) => { productRepository.Add(product); });

app.MapPut("/items", (Product product, IProductRepository productRepository) => { productRepository.Update(product); });

app.MapDelete("/items/{id}", (Guid id, IProductRepository productRepository) =>
{
    var product = productRepository.Get(id);
    productRepository.Delete(product);
});

app.Run();