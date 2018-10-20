CREATE PROCEDURE userAdd(@UserName varchar(25),@Password varchar(25),@Email varchar(50),@Gender char(2),@Auth varchar(15))
AS
BEGIN
INSERT INTO Users VALUES(@UserName,@Password,@Email,@Gender,@Auth);
END

