CREATE PROCEDURE isUser(@UserName VARCHAR(max),@Password VARCHAR(max))
AS
BEGIN

SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password;
END
