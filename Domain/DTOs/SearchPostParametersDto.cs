namespace Domain;

public class SearchPostParametersDto
{
    public string? Username { get;}
    public int? UserId { get;}
    public string? ContextContains { get;}
    public string? TitleContains { get;}
    public int? PostId { get; }

    public SearchPostParametersDto(string? username, int? userId, string? contextContains, string? titleContains, int? postId)
    {
        Username = username;
        UserId = userId;
        ContextContains = contextContains;
        TitleContains = titleContains;
        PostId = postId;
    }
}