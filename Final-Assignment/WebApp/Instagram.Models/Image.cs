namespace Instagram.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public string PostId { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
