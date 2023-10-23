using Domain;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetPosts(string? titleContains = null);
    Task<IEnumerable<Post>> GetByIdAsync(int id);

}