CREATE PROCEDURE postAdd(@PostTitle VARCHAR(max),@PostContent VARCHAR(max),@PostImage VARCHAR(max))
AS
BEGIN
DECLARE @PostId int;
INSERT INTO Posts(PostTitle,PostContent,PostImage) VALUES(@PostTitle,@PostContent,@PostImage)
SELECT @PostId=PostId FROM Posts WHERE PostTitle=@PostTitle AND PostContent=@PostContent;
RETURN @PostId;
END
