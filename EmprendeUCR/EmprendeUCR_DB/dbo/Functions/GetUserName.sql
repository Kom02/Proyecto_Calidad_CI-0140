CREATE FUNCTION [dbo].[GetUserName](  
@Email varchar(100))
RETURNS varchar(15)
AS
BEGIN	
	DECLARE @Nombre AS varchar(15)
    select @Nombre = U.Name
    from [User] U
    where @Email = U.Email 
RETURN @Nombre
END;