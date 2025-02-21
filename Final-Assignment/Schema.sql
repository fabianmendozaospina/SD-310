DROP TABLE IF EXISTS [Like];
DROP TABLE IF EXISTS [Image];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Message];
DROP TABLE IF EXISTS [View];
DROP TABLE IF EXISTS [Follower];
DROP TABLE IF EXISTS [Tag];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [User];
GO

CREATE TABLE [User] (
	userId INT IDENTITY(1,1) NOT NULL,
	username NVARCHAR(50) NOT NULL,
	firstName NVARCHAR(30) NOT NULL,
	lastName NVARCHAR(30) NOT NULL,
	[password] NVARCHAR(50) NOT NULL,
	email NVARCHAR(50) NOT NULL,
	bio NVARCHAR(MAX),
	profileUrl NVARCHAR(200),
	CONSTRAINT PK_User_userId
		PRIMARY KEY (userId),
	CONSTRAINT UQ_User_username
		UNIQUE (username),
	CONSTRAINT UQ_User_email
		UNIQUE (email),
	CONSTRAINT UQ_User_profileUrl
		UNIQUE (profileUrl)
);

CREATE TABLE Post (
	postId NVARCHAR(22) NOT NULL,
	userId INT NOT NULL,
	[timestamp] DATETIME NOT NULL,
	caption NVARCHAR(200) NOT NULL,
	isStory BIT NOT NULL,
	expiration DATETIME,
	CONSTRAINT PK_Post_postId
		PRIMARY KEY (postId),
	CONSTRAINT FK_Post_User_userId
		FOREIGN KEY (userId)
		REFERENCES [User](userId)
		ON DELETE CASCADE
);

CREATE TABLE [Message] (
	messageId INT IDENTITY(1,1) NOT NULL,
	senderId INT NOT NULL,
	receiverId INT NOT NULL,
	[message] NVARCHAR(MAX) NOT NULL,
	[timestamp] DATETIME NOT NULL,
	CONSTRAINT PK_Message_messageId
		PRIMARY KEY (messageId),
	CONSTRAINT FK_Message_User_senderId
		FOREIGN KEY (senderId)
		REFERENCES [User](userId)
		ON DELETE CASCADE,
	CONSTRAINT FK_Message_User_receiverId
		FOREIGN KEY (receiverId)
		REFERENCES [User](userId)
);

CREATE TABLE Follower (
	userId INT NOT NULL,
	followerId INT NOT NULL,
	CONSTRAINT UQ_Follower_userId_followerId
		UNIQUE (userId, followerId),
	CONSTRAINT FK_Follower_User_userId
		FOREIGN KEY (userId)
		REFERENCES [User](userId)
		ON DELETE CASCADE,
	CONSTRAINT FK_Follower_User_followerId
		FOREIGN KEY (followerId)
		REFERENCES [User](userId)
);

CREATE TABLE [View] (
	viewId INT IDENTITY(1,1) NOT NULL,
	userId INT NOT NULL,
	postId NVARCHAR(22) NOT NULL,
	[timestamp] DATETIME NOT NULL,
	CONSTRAINT PK_View_viewId
		PRIMARY KEY (viewId),
	CONSTRAINT FK_View_User_userId
		FOREIGN KEY (userId)
		REFERENCES [User](userId)
		ON DELETE CASCADE,
	CONSTRAINT FK_View_Post_postId
		FOREIGN KEY (postId)
		REFERENCES Post(postId)
);

CREATE TABLE Comment (
	commentId INT IDENTITY(1,1) NOT NULL,
	postId NVARCHAR(22) NOT NULL,
	userId INT NOT NULL,
	[timestamp] DATETIME NOT NULL,
	commentText NVARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_Comment_commentId
		PRIMARY KEY (commentId),
	CONSTRAINT FK_Comment_User_userId
		FOREIGN KEY (userId)
		REFERENCES [User](userId)
		ON DELETE CASCADE,
	CONSTRAINT FK_Comment_Post_postId
		FOREIGN KEY (postId)
		REFERENCES Post(postId)
);

CREATE TABLE [Like] (
	likeId INT IDENTITY(1,1) NOT NULL,
	userId INT NOT NULL,
	postId NVARCHAR(22) NOT NULL,
	[timestamp] DATETIME NOT NULL,
	CONSTRAINT PK_Like_likeId
		PRIMARY KEY (likeId),
	CONSTRAINT UQ_Like_userId_postId
		UNIQUE (userId, postId),
	CONSTRAINT FK_Like_User_userId
		FOREIGN KEY (userId)
		REFERENCES [User](userId)
		ON DELETE CASCADE,
	CONSTRAINT FK_Like_Post_postId
		FOREIGN KEY (postId)
		REFERENCES Post(postId)
);

CREATE TABLE [Image] (
	imageId INT IDENTITY(1,1) NOT NULL,
	postId NVARCHAR(22) NOT NULL,
	imageUrl NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_Image_imageId
		PRIMARY KEY (imageId),
	CONSTRAINT UQ_Image_postId_imageUrl
		UNIQUE (postId, imageUrl),
	CONSTRAINT FK_Image_Post_postId
		FOREIGN KEY (postId)
		REFERENCES Post(postId)
		ON DELETE CASCADE
);

CREATE TABLE Tag (
    tagId INT IDENTITY(1,1) NOT NULL,
    postId NVARCHAR(22) NOT NULL,
    userId INT NOT NULL,
    CONSTRAINT PK_Tag_tagId
        PRIMARY KEY (tagId),
    CONSTRAINT FK_Tag_Post_postId
        FOREIGN KEY (postId)
        REFERENCES Post(postId)
        ON DELETE CASCADE,
    CONSTRAINT FK_Tag_User_userId
        FOREIGN KEY (userId)
        REFERENCES [User](userId),
    CONSTRAINT UQ_Tag_postId_userId
        UNIQUE (postId, userId)
);

GO

CREATE TRIGGER trg_generate_postId
ON Post
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE P
       SET P.postId = LEFT(NEWID(), 4) + FORMAT(GETDATE(), 'yyyyMMddHHmmssffff')
      FROM Post P
           INNER JOIN inserted I ON P.postId = I.postId
     WHERE I.postId IS NULL;
END;

GO

CREATE TRIGGER trg_update_expiration
ON Post
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE P
       SET P.expiration = 
	       CASE WHEN I.isStory = 1 
		      THEN DATEADD(HOUR, 24, I.[timestamp])
              ELSE NULL
           END
    FROM Post P
    INNER JOIN inserted I ON P.postId = I.postId;
END;

GO


CREATE TRIGGER trg_validate_comments
ON Comment
AFTER INSERT
AS
BEGIN
    DELETE FROM Comment
    WHERE commentId IN (
        SELECT i.commentId
        FROM inserted i
        JOIN Post p ON i.postId = p.postId
        WHERE p.isStory = 1
    );

    IF @@ROWCOUNT > 0
    BEGIN
        THROW 50001, 'Cannot comment on a story.', 1;
    END
END;

