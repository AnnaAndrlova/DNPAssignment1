using Application.DaoInterfaces;
using Domain;

namespace FileData.DAOs;

public class PostFileDao: IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParams)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParams.Username))
        {
            // we know username is unique, so just fetch the first
            result = context.Posts.Where(post =>
                post.Author.UserName.Equals(searchParams.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParams.UserId != null)
        {
            result = result.Where(p => p.Author.Id == searchParams.UserId);
        }
        

        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            result = result.Where(p =>
                p.Title.Contains(searchParams.TitleContains, StringComparison.OrdinalIgnoreCase));
        }
        

        if (!string.IsNullOrEmpty(searchParams.ContextContains))
        {
            result = result.Where(p =>
                p.Context.Contains(searchParams.ContextContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);
    }
}