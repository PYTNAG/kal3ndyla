namespace Kal3ndyla.Core.Products;

public class ProductsQuery<TFields>(TFields fields, Guid? guid = null, string? author = null, string? title = null)
{
    public Guid? Guid { get; } = guid;
    public string? AuthorSubstring { get; } = author;
    public string? TitleSubstring { get; } = title;
    public TFields Fields { get; } = fields;
}