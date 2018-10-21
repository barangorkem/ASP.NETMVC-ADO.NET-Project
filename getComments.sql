CREATE PROCEDURE getComments
AS
BEGIN

SELECT c.CommentId,c.CommentContent,c.CommentDate,u.UserName,p.PostId  FROM Comments c JOIN Posts p ON c.PostId=p.PostId JOIN Users u ON u.UserId=c.UserId;

END
