namespace Kal3ndyla.Infrastructure.Exceptions;

public class TrackNotFoundException(Guid guid) 
    : Exception($"Track with GUID {guid} not found")
{
}