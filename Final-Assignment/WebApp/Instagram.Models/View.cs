namespace Instagram.Models;

public partial class View
{
    public int ViewId { get; set; }

    public int UserId { get; set; }

    public string PostId { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
