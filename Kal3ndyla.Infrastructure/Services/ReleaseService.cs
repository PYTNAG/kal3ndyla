using Kal3ndyla.Core.Products;
using Kal3ndyla.Core.Releases;
using Kal3ndyla.Infrastructure.Services.Interfaces;

namespace Kal3ndyla.Infrastructure.Services;

public class ReleaseService : IProductService<ReleaseFields>
{
    public Guid AddProduct(CommonProductInfo<ReleaseFields> commonProductInfo)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Product<ReleaseFields> GetProduct(Guid guid)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product<ReleaseFields>> GetProducts(ProductsQuery<ReleaseFields> productsQuery)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product<ReleaseFields> track)
    {
        throw new NotImplementedException();
    }
}
