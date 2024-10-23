namespace Kal3ndyla.Persistence.Models.Base;

public class ProductModelBase : ModelBase
{
    public required Guid Guid { get; set; }
    public required string Author { get; set; }
    public required string Title { get; set; } 
}