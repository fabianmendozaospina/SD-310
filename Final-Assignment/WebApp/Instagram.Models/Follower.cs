namespace Instagram.Models;

public partial class Follower
{
    public int UserId { get; set; }

    public int FollowerId { get; set; }

    public virtual User FollowerNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
