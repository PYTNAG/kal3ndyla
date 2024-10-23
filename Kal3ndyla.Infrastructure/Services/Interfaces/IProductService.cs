using Kal3ndyla.Core.Products;

namespace Kal3ndyla.Infrastructure.Services.Interfaces;

public interface IProductService<TFields>
{
    public Guid AddProduct(CommonProductInfo<TFields> commonProductInfo);

    public void DeleteProduct(Guid guid);
    public void UpdateProduct(Product<TFields> track);

    public IEnumerable<Product<TFields>> GetProducts(ProductsQuery<TFields> productsQuery);
    public Product<TFields> GetProduct(Guid guid);
}