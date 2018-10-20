CREATE PROCEDURE postFind(@PostId int)
AS
BEGIN

SELECT * FROM Posts WHERE PostId=@PostId;

END
