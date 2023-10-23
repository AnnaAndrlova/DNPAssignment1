using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao todoDao, IUserDao userDao)
    {
        postDao = todoDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.AuthorId);
        if (user == null) throw new Exception($"User with id {dto.AuthorId} was not found.");

        ValidatePost(dto);
        Post todo = new Post(user, dto.Title, dto.Context, DateTime.Now.Date);
        Post created = await postDao.CreateAsync(todo);
        return created;
    }
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Context)) throw new Exception("Context cannot be empty.");
        // other validation stuff
    }
}