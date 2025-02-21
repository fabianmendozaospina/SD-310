using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Instagram.Models;

public partial class Message
{
    public int MessageId { get; set; }

    [Required(ErrorMessage = "Sender is required.")]
    public int SenderId { get; set; }

    [Required(ErrorMessage = "Receiver is required.")]
    public int ReceiverId { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    public string MessageText { get; set; } = null!;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public virtual User Receiver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
