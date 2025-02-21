--6.

SELECT TOP 5
    U.userId,
    U.username,
    COUNT(DISTINCT L.likeId) + COUNT(DISTINCT C.commentId) AS total_support
FROM 
    [User] U
LEFT JOIN 
    [Like] L ON U.userId = L.userId AND L.postId = 'post5'
LEFT JOIN 
    [Comment] C ON U.userId = C.userId AND C.postId = 'post5'
WHERE 
    U.userId != 5
GROUP BY 
    U.userId, U.username
ORDER BY 
    total_support DESC;

-- only one person besides aplasticplant themselves have showed support in the context of this database, so the other 4 users are randomly selected


--7.

SELECT TOP 1
    U.username,
    COUNT(V.viewId) AS total_views
FROM 
    dbo.Post P
JOIN 
    dbo.[View] V ON P.postId = V.postId
JOIN 
    dbo.[User] U ON P.userId = U.userId
WHERE 
    P.isStory = 1
GROUP BY 
    U.username
ORDER BY 
    total_views DESC
-- When views are added and assigned to the stories, the program works, but since by default there are no views it will return no users

--8.

SELECT TOP 1
	U.username,
	COUNT(L.likeId) AS total_likes
FROM
	dbo.[Like] L
JOIN     
	dbo.Post P ON L.postId = P.postId
JOIN 
    dbo.[User] U ON L.userId = U.userId
WHERE 
    P.userId = (SELECT userId FROM dbo.[User] WHERE username = 'movie_quotes')
    AND P.isStory = 1
GROUP BY 
    U.username
ORDER BY total_likes DESC

--9

SELECT DISTINCT 
    P.postId, 
    P.caption, 
    P.timestamp
FROM 
    dbo.[Like] L
JOIN 
    dbo.Post P ON L.postId = P.postId
WHERE 
    L.userId IN (SELECT userId FROM dbo.Comment WHERE postId = '412EL5357109');

--10.

WITH FollowedUsers AS (
    SELECT f.userId AS followedUserId
    FROM dbo.Follower f
    WHERE f.followerId = (SELECT userId FROM dbo.[User] WHERE username = 'lifeoftheparty')
),

FirstMessage AS (
    SELECT 
        m.receiverId AS followedUserId,
        MIN(m.timestamp) AS firstMessageTime
    FROM dbo.Message m
    JOIN FollowedUsers f ON m.receiverId = f.followedUserId
    WHERE m.senderId = (SELECT userId FROM dbo.[User] WHERE username = 'lifeoftheparty')
    GROUP BY m.receiverId
),

FirstPost AS (
    SELECT
        p.userId AS followedUserId,
        MIN(p.timestamp) AS firstPostTime
    FROM dbo.Post p
    JOIN FollowedUsers f ON p.userId = f.followedUserId
    GROUP BY p.userId
)

SELECT 
    u.username AS followedUsername,
    u.firstName,
    u.lastName,
    fp.firstPostTime,
    fm.firstMessageTime
FROM 
	FollowedUsers fu
JOIN 
	dbo.[User] u ON u.userId = fu.followedUserId
JOIN 
	FirstMessage fm ON fm.followedUserId = fu.followedUserId
JOIN 
	FirstPost fp ON fp.followedUserId = fu.followedUserId
WHERE 
	fp.firstPostTime > fm.firstMessageTime

ORDER BY fp.firstPostTime;

-- In the case of this database, nobody in the followers tab meets the requirements, but when the data is edited the query works as intended