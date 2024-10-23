namespace Kal3ndyla.Infrastructure.Services.Interfaces;

public interface IPersistenceMapperService<TModel, TDto>
{
    public TModel ToModel(TDto dto);
    public TDto ToDto(TModel model);
}