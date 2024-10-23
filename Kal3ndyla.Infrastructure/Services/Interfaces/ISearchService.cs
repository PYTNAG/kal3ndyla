using Kal3ndyla.Core.Products;

namespace Kal3ndyla.Infrastructure.Services.Interfaces;

public interface ISearchService<TModel, TFields>
{
    public IEnumerable<TModel> Search(IQueryable<TModel> heap, ProductsQuery<TFields> query);
}