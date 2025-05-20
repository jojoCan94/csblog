namespace BlogProject.Models;

public class Comment 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int IdPost { get; set; }
}