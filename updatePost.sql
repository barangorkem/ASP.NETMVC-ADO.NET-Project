CREATE PROCEDURE updatePost(@PostId int,@PostTitle VARCHAR(max),@PostContent VARCHAR(MAX))
AS
BEGIN

UPDATE Posts SET PostTitle=@PostTitle,PostContent=@PostContent WHERE PostId=@PostId;

END
