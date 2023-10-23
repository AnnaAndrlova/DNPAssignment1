namespace Domain;

public class Post
{
    public Post(User author, string title, string context, DateTime dateOfCreation)
    {
        Author = author;
        Title = title;
        Context = context;
        DateOfCreation = dateOfCreation;
    }

    public int Id { get; set; }
    public User Author { get; }
    public string Title { get; }
    public string Context { get; }
    public DateTime DateOfCreation { get; }
}