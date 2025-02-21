namespace Instagram.Models;

public partial class Like
{
    public int LikeId { get; set; }

    public int UserId { get; set; }

    public string PostId { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
