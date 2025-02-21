namespace Instagram.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string PostId { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
