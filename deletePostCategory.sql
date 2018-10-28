CREATE PROCEDURE deletePostCategory(@PostId int)
AS
BEGIN
DELETE FROM PostCategories WHERE PostId=@PostId;
END
