using Instagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.DAL;

public partial class InstagramContext : DbContext
{
    public InstagramContext()
    {
    }

    public InstagramContext(DbContextOptions<InstagramContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Follower> Followers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<View> Views { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=FEMO\\SQLEXPRESS;Database=Instagram;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK_Comment_commentId");

            entity.ToTable("Comment", tb => tb.HasTrigger("trg_validate_comments"));

            entity.Property(e => e.CommentId).HasColumnName("commentId");
            entity.Property(e => e.CommentText).HasColumnName("commentText");
            entity.Property(e => e.PostId)
                .HasMaxLength(22)
                .HasColumnName("postId");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Follower>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Follower");

            entity.HasIndex(e => new { e.UserId, e.FollowerId }, "UQ_Follower_userId_followerId").IsUnique();

            entity.Property(e => e.FollowerId).HasColumnName("followerId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.FollowerNavigation).WithMany()
                .HasForeignKey(d => d.FollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany().HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK_Image_imageId");

            entity.ToTable("Image");

            entity.HasIndex(e => new { e.PostId, e.ImageUrl }, "UQ_Image_postId_imageUrl").IsUnique();

            entity.Property(e => e.ImageId).HasColumnName("imageId");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .HasColumnName("imageUrl");
            entity.Property(e => e.PostId)
                .HasMaxLength(22)
                .HasColumnName("postId");

            entity.HasOne(d => d.Post).WithMany(p => p.Images).HasForeignKey(d => d.PostId);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("PK_Like_likeId");

            entity.ToTable("Like");

            entity.HasIndex(e => new { e.UserId, e.PostId }, "UQ_Like_userId_postId").IsUnique();

            entity.Property(e => e.LikeId).HasColumnName("likeId");
            entity.Property(e => e.PostId)
                .HasMaxLength(22)
                .HasColumnName("postId");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Post).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Likes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK_Message_messageId");

            entity.ToTable("Message");

            entity.Property(e => e.MessageId).HasColumnName("messageId");
            entity.Property(e => e.MessageText).HasColumnName("message");
            entity.Property(e => e.ReceiverId).HasColumnName("receiverId");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders).HasForeignKey(d => d.SenderId);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK_Post_postId");

            entity.ToTable("Post", tb =>
                {
                    tb.HasTrigger("trg_generate_postId");
                    tb.HasTrigger("trg_update_expiration");
                });

            entity.Property(e => e.PostId)
                .HasMaxLength(22)
                .HasColumnName("postId");
            entity.Property(e => e.Caption)
                .HasMaxLength(200)
                .HasColumnName("caption");
            entity.Property(e => e.Expiration)
                .HasColumnType("datetime")
                .HasColumnName("expiration");
            entity.Property(e => e.IsStory).HasColumnName("isStory");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK_Tag_tagId");

            entity.ToTable("Tag");

            entity.HasIndex(e => new { e.PostId, e.UserId }, "UQ_Tag_postId_userId").IsUnique();

            entity.Property(e => e.TagId).HasColumnName("tagId");
            entity.Property(e => e.PostId)
                .HasMaxLength(22)
                .HasColumnName("postId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Post).WithMany(p => p.Tags).HasForeignKey(d => d.PostId);

            entity.HasOne(d => d.User).WithMany(p => p.Tags)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User_userId");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ_User_email").IsUnique();

            entity.HasIndex(e => e.ProfileUrl, "UQ_User_profileUrl").IsUnique();

            entity.HasIndex(e => e.Username, "UQ_User_username").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.ProfileUrl)
                .HasMaxLength(200)
                .HasColumnName("profileUrl");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<View>(entity =>
        {
            entity.HasKey(e => e.ViewId).HasName("PK_View_viewId");

            entity.ToTable("View");

            entity.Property(e => e.ViewId).HasColumnName("viewId");
            entity.Property(e => e.PostId)
                .HasMaxLength(22)
                .HasColumnName("postId");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Post).WithMany(p => p.Views)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Views).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
