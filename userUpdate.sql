CREATE PROCEDURE userUpdate(@UserId int,@UserName VARCHAR(25),@Password VARCHAR(25),@Email VARCHAR(50),@Gender CHAR(2),@Auth VARCHAR(15))
AS
BEGIN
UPDATE Users SET UserName=@UserName,Password=@Password,Email=@Email,Gender=@Gender,Auth=@Auth WHERE UserId=@UserId;
end