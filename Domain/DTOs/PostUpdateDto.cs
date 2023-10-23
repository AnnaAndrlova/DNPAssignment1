namespace Domain;

public class PostUpdateDto
{
    public int Id { get; }
    public User? Author { get; }
    public string? Title { get; set; }
    public string? Context { get; set; }
    public DateTime? DateOfCreation { get; }

    public PostUpdateDto(int id)
    {
        Id = id;
    }
}