using System;
using System.Collections.Generic;

namespace Instagram.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string PostId { get; set; } = null!;

    public int UserId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
