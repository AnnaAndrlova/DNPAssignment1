namespace Domain;

public class PostCreationDto
{
    public PostCreationDto(int authorId, string title, string context)
    {
        AuthorId = authorId;
        Title = title;
        Context = context;
        DateOfCreation = DateTime.Now;
    }

    public int AuthorId { get; }
    public string Title { get; }
    public string Context { get; }
    public DateTime DateOfCreation { get; }
}