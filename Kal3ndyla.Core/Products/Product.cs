namespace Kal3ndyla.Core.Products;

public class Product<TFields>(Guid guid, string author, string title, TFields fields) 
    : CommonProductInfo<TFields>(author, title, fields)
{
    public Guid Guid { get; } = guid;
}