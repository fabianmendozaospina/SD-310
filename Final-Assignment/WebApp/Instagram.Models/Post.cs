using System;
using System.Collections.Generic;

namespace Instagram.Models;

public partial class Post
{
    public string PostId { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string Caption { get; set; } = null!;

    public bool IsStory { get; set; }

    public DateTime? Expiration { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<View> Views { get; set; } = new List<View>();
}
