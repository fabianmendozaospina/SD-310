CREATE TABLE [User] (
	userId INT IDENTITY(1,1) NOT NULL,
	username NVARCHAR(50) NOT NULL,
	firstName NVARCHAR(30) NOT NULL,
	lastName NVARCHAR(30) NOT NULL,
	[password] NVARCHAR(50) NOT NULL,
	email NVARCHAR(50) NOT NULL,
	bio NVARCHAR(MAX),
	profileUrl NVARCHAR(200) NOT NULL
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
	postId INT IDENTITY(1,1) NOT NULL,
	userId INT NOT NULL,
	[timestamp] TIMESTAMP NOT NULL,
	caption VARCHAR(50) NOT NULL,
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
	[timestamp] TIMESTAMP NOT NULL,
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

CREATE TABLE Story (
	storyId INT IDENTITY(1,1) NOT NULL,
	userId INT NOT NULL,
	expiration TIMESTAMP NOT NULL,
	CONSTRAINT PK_Story_storyId
		PRIMARY KEY (storyId),
	CONSTRAINT FK_Story_User_userId
		FOREIGN KEY (userId)
		REFERENCES [User](userId)
		ON DELETE CASCADE
);

CREATE TABLE Comment (
	commentId INT IDENTITY(1,1) NOT NULL,
	postId INT NOT NULL,
	userId INT NOT NULL,
	[timestamp] TIMESTAMP NOT NULL,
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
	postId INT NOT NULL,
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
	postId INT NOT NULL,
	imageUrl NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_Image_imageId
		PRIMARY KEY (imageId),
	CONSTRAINT UQ_Like_postId_imageUrl
		UNIQUE (postId, imageUrl),
	CONSTRAINT FK_Image_Post_postId
		FOREIGN KEY (postId)
		REFERENCES Post(postId)
		ON DELETE CASCADE
);