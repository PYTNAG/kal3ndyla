using Kal3ndyla.Core.Products;
using Kal3ndyla.Infrastructure.Services.Interfaces;
using Kal3ndyla.Persistence.Contexts;

namespace Kal3ndyla.Infrastructure.Services.Base;

public abstract class ProductService<TModel, TFields>(Kal3ndylaContext db, ISearchService<TModel, TFields> searchService) 
    : IProductService<TFields>
{
    private readonly Kal3ndylaContext _db = db;
    private readonly ISearchService<TModel, TFields> _searchService = searchService;

    public Guid AddProduct(CommonProductInfo<TFields> commonProductInfo)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Product<TFields> GetProduct(Guid guid)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product<TFields>> GetProducts(ProductsQuery<TFields> productsQuery)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product<TFields> track)
    {
        throw new NotImplementedException();
    }
}