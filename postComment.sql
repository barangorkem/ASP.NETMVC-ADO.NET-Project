CREATE PROCEDURE postComment(@PostId int)
AS
BEGIN
SELECT c.CommentId,c.CommentContent,c.CommentDate,u.UserName FROM comments c JOIN Users u ON u.UserId=c.UserId WHERE c.postId=@PostId;
END