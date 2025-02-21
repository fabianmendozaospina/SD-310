INSERT INTO [User] (username, firstName, lastName, [password], email, bio, profileUrl)
VALUES 
('cristiano', 'Cristiano', 'Ronaldo', 'cr7password', 'cristiano@example.com', 'Football legend', 'https://i.imgflip.com/9ky855.jpg'),
('messi', 'Lionel', 'Messi', 'messi10password', 'messi@example.com', 'Football magician', 'https://i.imgflip.com/9ky8c1.jpg'),
('serenawilliams', 'Serena', 'Williams', 'serenapassword', 'serena@example.com', 'Tennis champion', 'https://i.imgflip.com/9ky8sd.jpg'),
('that_talkative_user', 'John', 'Doe', 'talkativepassword', 'john@example.com', 'I love to chat', 'https://example.com/john.jpg'),
('aplasticplant', 'Plastic', 'Plant', 'plantpassword', 'plant@example.com', 'Just a plant', 'https://example.com/plant.jpg'),
('movie_quotes', 'Movie', 'Quotes', 'quotespassword', 'quotes@example.com', 'I love movies', 'https://example.com/quotes.jpg'),
('lifeoftheparty', 'Party', 'Animal', 'partypassword', 'party@example.com', 'Life is a party', 'https://example.com/party.jpg'),
('user1', 'User', 'One', 'user1password', 'user1@example.com', 'Just another user', 'https://example.com/user1.jpg'),
('user2', 'User', 'Two', 'user2password', 'user2@example.com', 'Just another user', 'https://example.com/user2.jpg'),
('user3', 'User', 'Three', 'user3password', 'user3@example.com', 'Just another user', 'https://example.com/user3.jpg');

INSERT INTO Follower (userId, followerId)
VALUES 
(2, 1),  -- Cristiano follows Messi
(1, 2),  -- Messi follows Cristiano
(1, 3),  -- Serena follows Cristiano
(1, 4),  -- that_talkative_user follows Cristiano
(1, 5),  -- aplasticplant follows Cristiano
(1, 6),  -- movie_quotes follows Cristiano
(1, 7),  -- lifeoftheparty follows Cristiano
(3, 1),  -- Cristiano follows Serena
(3, 2),  -- Messi follows Serena
(2, 3);  -- Serena follows Messi

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

INSERT INTO Comment (postId, userId, [timestamp])
VALUES 
('412EL5357109', 2, '2023-10-01 12:05:00'),  -- Messi comments on Cristiano's post
('post2', 1, '2023-10-02 12:05:00'),         -- Cristiano comments on Messi's post
('post3', 2, '2023-10-03 12:05:00'),         -- Messi comments on Serena's post
('post4', 3, '2023-10-04 12:05:00'),         -- Serena comments on Talkative's post
('post5', 4, '2023-10-05 12:05:00'),         -- Talkative comments on Plant's post
('post6', 5, '2023-10-06 12:05:00'),         -- Plant comments on Movie quotes' post
('post7', 6, '2023-10-07 12:05:00');         -- Movie quotes comments on Party's post

INSERT INTO [Like] (userId, postId)
VALUES 
(2, '412EL5357109'),  -- Messi likes Cristiano's post
(1, 'post2'),         -- Cristiano likes Messi's post
(3, 'post3'),         -- Serena likes her own post
(4, 'post4'),         -- Talkative likes his own post
(5, 'post5'),         -- Plant likes his own post
(6, 'post6'),         -- Movie quotes likes his own post
(7, 'post7');         -- Party likes his own post

INSERT INTO [Image] (postId, imageUrl)
VALUES 
('412EL5357109', 'https://example.com/cristiano_post1.jpg'),
('post2', 'https://example.com/messi_post1.jpg'),
('post3', 'https://example.com/serena_post1.jpg'),
('post4', 'https://example.com/talkative_post1.jpg'),
('post5', 'https://example.com/plant_post1.jpg'),
('post6', 'https://example.com/quotes_post1.jpg'),
('post7', 'https://example.com/party_post1.jpg');

INSERT INTO [Message] (senderId, receiverId, [message], [timestamp])
VALUES 
(4, 1, 'Hi Cristiano!', '2022-03-12 07:22:00'),  -- Talkative sends a message to Cristiano
(1, 4, 'Hello!', '2022-03-12 07:25:00'),         -- Cristiano replies to Talkative
(4, 2, 'Hi Messi!', '2022-03-12 07:30:00'),      -- Talkative sends a message to Messi
(2, 4, 'Hello!', '2022-03-12 07:35:00'),         -- Messi replies to Talkative
(4, 3, 'Hi Serena!', '2022-03-12 07:40:00'),     -- Talkative sends a message to Serena
(3, 4, 'Hello!', '2022-03-12 07:45:00');         -- Serena replies to Talkative

INSERT INTO [View] (userId, postId)
VALUES 
(2, '412EL5357109'),  -- Messi views Cristiano's post
(1, 'post2'),         -- Cristiano views Messi's post
(3, 'post3'),         -- Serena views her own post
(4, 'post4'),         -- Talkative views his own post
(5, 'post5'),         -- Plant views his own post
(6, 'post6'),         -- Movie quotes views his own post
(7, 'post7');         -- Party views his own post

INSERT INTO Tag (postId, userId)
VALUES 
('412EL5357109', 2),  -- Messi is tagged in Cristiano's post
('post2', 1),         -- Cristiano is tagged in Messi's post
('post3', 3),         -- Serena is tagged in her own post
('post4', 4),         -- Talkative is tagged in his own post
('post5', 5),         -- Plant is tagged in his own post
('post6', 6),         -- Movie quotes is tagged in his own post
('post7', 7);         -- Party is tagged in his own post