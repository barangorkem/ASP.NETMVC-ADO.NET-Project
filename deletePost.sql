﻿
CREATE PROCEDURE deletePost (@PostId INT)
AS
BEGIN

DELETE FROM Posts WHERE PostId=@PostId;

END
