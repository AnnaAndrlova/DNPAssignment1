using Domain;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
}