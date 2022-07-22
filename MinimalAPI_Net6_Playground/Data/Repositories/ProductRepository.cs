using MinimalAPI_Net6_Playground.Data.Models;

namespace MinimalAPI_Net6_Playground.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IList<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Update(Product product)
    {
        var listProduct = _products.Single(p => p.Id == product.Id);

        listProduct.Description = product.Description;
        listProduct.Quantity = product.Quantity;
    }

    public void Delete(Product product)
    {
        _products.Remove(product);
    }

    public Product Get(Guid id)
    {
        return _products.Single(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
}

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    Product Get(Guid id);
    IEnumerable<Product> GetAll();
}