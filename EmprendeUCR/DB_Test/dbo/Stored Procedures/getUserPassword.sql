CREATE PROCEDURE getUserPassword(@Email varchar(100))
AS
BEGIN
	SELECT [Password] FROM [dbo].[Credentials] WHERE [User_Email] = @Email
END