namespace Domain;


public class PostBasicDto
{
    public int Id { get; }
    public User Author { get; }
    public string Title { get; }
    public string Context { get;  }
    public DateTime DateOfCreation { get; }

    public PostBasicDto(int id, User author, string title, string context, DateTime dateOfCreation)
    {
        Id = id;
        Author = author;
        Title = title;
        Context = context;
        DateOfCreation = dateOfCreation;
    }
}