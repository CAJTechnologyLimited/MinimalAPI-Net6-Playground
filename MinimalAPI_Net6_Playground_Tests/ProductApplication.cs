using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinimalAPI_Net6_Playground.Data.Models;
using MinimalAPI_Net6_Playground.Data.Repositories;

namespace MinimalAPI_Net6_Playground_Tests;

internal class ProductApplication : WebApplicationFactory<Product>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services => { services.AddScoped<IProductRepository, ProductRepository>(); });

        return base.CreateHost(builder);
    }
}