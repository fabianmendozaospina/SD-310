using System;
using System.Collections.Generic;

namespace Instagram.Models;

public partial class View
{
    public int ViewId { get; set; }

    public int UserId { get; set; }

    public string PostId { get; set; } = null!;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
