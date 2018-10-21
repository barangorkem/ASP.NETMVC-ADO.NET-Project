CREATE PROCEDURE commentDelete(@CommentId int)
AS
BEGIN

DELETE FROM Comments WHERE CommentId=@CommentId;

END
