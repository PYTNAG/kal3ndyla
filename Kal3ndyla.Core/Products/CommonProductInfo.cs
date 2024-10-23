namespace Kal3ndyla.Core.Products;

public class CommonProductInfo<TFields>(string author, string title, TFields fields)
{
    public string Author { get; } = author;
    public string Title { get; } = title;
    public TFields Fields { get; } = fields;
}