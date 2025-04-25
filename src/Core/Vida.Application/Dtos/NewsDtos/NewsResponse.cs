namespace Vida.Application.Dtos.NewsDtos;

public class NewsResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public DateTime PublishDate { get; set; }

    public string Category { get; set; } = string.Empty;
}
