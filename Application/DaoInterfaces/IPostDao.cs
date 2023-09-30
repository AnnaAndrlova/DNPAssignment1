using Domain;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post todo);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
}