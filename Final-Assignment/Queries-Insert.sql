INSERT INTO [User] (username, firstName, lastName, [password], email, bio, profileUrl)
VALUES 
('cristiano', 'Cristiano', 'Ronaldo', 'cr7password', 'cristiano@example.com', 'Football legend', 'https://i.imgflip.com/9ky855.jpg'),
('messi', 'Lionel', 'Messi', 'messi10password', 'messi@example.com', 'Football magician', 'https://i.imgflip.com/9ky8c1.jpg'),
('serenawilliams', 'Serena', 'Williams', 'serenapassword', 'serena@example.com', 'Tennis champion', 'https://i.imgflip.com/9ky8sd.jpg'),
('that_talkative_user', 'John', 'Doe', 'talkativepassword', 'john@example.com', 'I love to chat', 'https://i.imgflip.com/9ky6ty.jpg'),
('aplasticplant', 'Plastic', 'Plant', 'plantpassword', 'plant@example.com', 'Just a plant', 'https://i.imgflip.com/9ky6zh.jpg'),
('movie_quotes', 'Movie', 'Quotes', 'quotespassword', 'quotes@example.com', 'I love movies', 'https://i.imgflip.com/9ky761.jpg'),
('lifeoftheparty', 'Party', 'Animal', 'partypassword', 'party@example.com', 'Life is a party', 'https://i.imgflip.com/9ky7eu.jpg'),
('user1', 'User', 'One', 'user1password', 'user1@example.com', 'Just another user', 'https://i.imgflip.com/9ky7m7.jpg'),
('user2', 'User', 'Two', 'user2password', 'user2@example.com', 'Just another user', 'https://i.imgflip.com/9ky7qr.jpg'),
('user3', 'User', 'Three', 'user3password', 'user3@example.com', 'Just another user', 'https://i.imgflip.com/9ky7xc.jpg');

INSERT INTO Follower (userId, followerId)
VALUES 
(1, 2), 
(2, 1),  
(3, 1),  
(4, 1),  
(5, 1),  
(6, 1),  
(7, 1), 
(1, 3),  
(2, 3),  
(3, 2),  
(4, 2),
(4, 3),
(5, 2),
(5, 3),
(6, 2),
(6, 3),
(7, 2),
(7, 3);

INSERT INTO Post (postId, userId, [timestamp], caption, isStory)
VALUES 
('412EL5357109', 1, '2023-10-01 12:00:00', 'My first post', 0),  -- Cristiano's post
('post2', 2, '2023-10-02 12:00:00', 'Messi post', 0),             -- Messi's post
('post3', 3, '2023-10-03 12:00:00', 'Serena post', 0),            -- Serena's post
('post4', 4, '2023-10-04 12:00:00', 'Talkative post', 0),         -- Talkative's post
('post5', 5, '2023-10-05 12:00:00', 'Plant post', 0),             -- Plant's post
('post6', 6, '2023-10-06 12:00:00', 'Movie quotes post', 0),      -- Movie quotes' post
('post7', 7, '2023-10-07 12:00:00', 'Party post', 0),             -- Party's post
('story1', 1, '2023-10-01 12:00:00', 'My first story', 1),        -- Cristiano's story
('story2', 2, '2023-10-02 12:00:00', 'Messi story', 1),           -- Messi's story
('story3', 3, '2023-10-03 12:00:00', 'Serena story', 1);          -- Serena's story

--INSERT INTO Comment (postId, userId, [timestamp], commentText)
--VALUES 
--('412EL5357109', 2, '2023-10-01 12:05:00', 'Great post!'),  -- Messi comments on Cristiano's post
--('post2', 1, '2023-10-02 12:05:00', 'Nice one!'),			-- Cristiano comments on Messi's post
--('post3', 2, '2023-10-03 12:05:00', 'Amazing!'),			-- Messi comments on Serena's post
--('post4', 3, '2023-10-04 12:05:00', 'Cool!'),				-- Serena comments on Talkative's post
--('post5', 4, '2023-10-05 12:05:00', 'Interesting!'),        -- Talkative comments on Plant's post
--('post6', 5, '2023-10-06 12:05:00', 'Love it!'),			-- Plant comments on Movie quotes' post
--('post7', 6, '2023-10-07 12:05:00', 'Awesome!');			-- Movie quotes comments on Party's post

INSERT INTO [Like] (userId, postId, [timestamp])
VALUES 
(2, '412EL5357109', '2023-10-01 12:10:00'),
(1, 'post2', '2023-10-02 12:10:00'),
(3, 'post3', '2023-10-03 12:10:00'),
(4, 'post4', '2023-10-04 12:10:00'),
(5, 'post5', '2023-10-05 12:10:00'),
(6, 'post6', '2023-10-06 12:10:00'),
(7, 'post7', '2023-10-07 12:10:00');

INSERT INTO [Image] (postId, imageUrl)
VALUES 
('412EL5357109', 'https://cdn.pixabay.com/photo/2025/02/20/11/39/mystery-9419680_1280.jpg'),
('post2', 'https://cdn.pixabay.com/photo/2025/02/20/11/42/model-9419688_1280.jpg'),
('post3', 'https://cdn.pixabay.com/photo/2025/02/20/11/49/waterfall-9419706_1280.jpg'),
('post4', 'https://cdn.pixabay.com/photo/2025/02/20/11/49/waterfall-9419705_1280.jpg'),
('post5', 'https://cdn.pixabay.com/photo/2025/02/20/11/42/cake-9419690_1280.jpg'),
('post6', 'https://cdn.pixabay.com/photo/2024/04/01/06/57/cookies-8668140_1280.jpg'),
('post7', 'https://cdn.pixabay.com/photo/2017/01/31/16/43/cheesecake-2025421_1280.png');

INSERT INTO [Message] (senderId, receiverId, [message], [timestamp])
VALUES 
(4, 1, 'Hi Cristiano!', '2022-03-12 07:22:00'),  -- Talkative sends a message to Cristiano
(1, 4, 'Hello!', '2022-03-12 07:25:00'),         -- Cristiano replies to Talkative
(4, 2, 'Hi Messi!', '2022-03-12 07:30:00'),      -- Talkative sends a message to Messi
(2, 4, 'Hello!', '2022-03-12 07:35:00'),         -- Messi replies to Talkative
(4, 3, 'Hi Serena!', '2022-03-12 07:40:00'),     -- Talkative sends a message to Serena
(3, 4, 'Hello!', '2022-03-12 07:45:00');         -- Serena replies to Talkative

INSERT INTO [View] (userId, postId, [timestamp])
VALUES 
(2, '412EL5357109', '2023-10-01 12:15:00'),
(1, 'post2', '2023-10-02 12:15:00'),
(3, 'post3', '2023-10-03 12:15:00'),
(4, 'post4', '2023-10-04 12:15:00'),
(5, 'post5', '2023-10-05 12:15:00'),
(6, 'post6', '2023-10-06 12:15:00'),
(7, 'post7', '2023-10-07 12:15:00');


INSERT INTO Tag (postId, userId)
VALUES 
('412EL5357109', 2),  -- Messi is tagged in Cristiano's post
('post2', 1),         -- Cristiano is tagged in Messi's post
('post3', 3),         -- Serena is tagged in her own post
('post4', 4),         -- Talkative is tagged in his own post
('post5', 5),         -- Plant is tagged in his own post
('post6', 6),         -- Movie quotes is tagged in his own post
('post7', 7);         -- Party is tagged in his own post