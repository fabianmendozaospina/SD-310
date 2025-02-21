using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Instagram.Models;

public partial class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CommentId { get; set; }

    public string PostId { get; set; } = null!;

    public int UserId { get; set; }
    [Column("timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    [Required(ErrorMessage = "Comment is required.")]
    public string CommentText { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
