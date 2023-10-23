using System.Collections;

namespace Domain;


public class PostBasicDto
{
    public int Id { get; }
    public User Author { get; }
    public string Title { get; }
    public string Context { get;  }
    

    public PostBasicDto(int id, User author, string title, string context)
    {
        Id = id;
        Author = author;
        Title = title;
        Context = context;
    }

    
}