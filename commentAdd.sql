CREATE PROCEDURE commentAdd(@CommentContent varchar(MAX),@CommentDate DATETIME,@UserId int,@PostId int)
AS
BEGIN

INSERT INTO Comments VALUES(@CommentContent,@CommentDate,@UserId,@PostId);

END