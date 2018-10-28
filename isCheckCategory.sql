CREATE PROCEDURE isCheckCategory(@PostId int,@CategoryId int)
AS
BEGIN
DECLARE @RECORDCOUNT int;
SET @RECORDCOUNT=(SELECT COUNT(PostId) FROM PostCategories WHERE PostId=@PostId AND CategoryId=@CategoryId);
RETURN @RECORDCOUNT;
END