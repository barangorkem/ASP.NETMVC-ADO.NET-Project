CREATE PROCEDURE postcategoryAdd(@PostId INT,@CategoryId int)
AS
BEGIN
INSERT INTO PostCategories(PostId,CategoryId) VALUES(@PostId,@CategoryId);
END
