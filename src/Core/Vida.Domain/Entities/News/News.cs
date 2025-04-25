using Vida.Domain.Common;

namespace Vida.Domain.Entities.News;

public class News : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public DateTime PublishDate { get; set; }

    public bool IsActive { get; set; } = true;

    public string Category { get; set; } = string.Empty;
}