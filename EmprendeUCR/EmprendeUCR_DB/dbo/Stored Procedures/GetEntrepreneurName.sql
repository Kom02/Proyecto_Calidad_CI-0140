CREATE PROCEDURE [dbo].[GetEntrepreneurName]  
@Email varchar(100),  
@Nombre varchar(15) OUTPUT  
AS
BEGIN	
    select DISTINCT @Nombre = U.Name
    from [User] U JOIN [Entrepreneur] E 
	on Email = E.User_Email JOIN [ORDER] O 
	on O.Entrepreneur_Email = E.User_Email
    where O.Entrepreneur_Email = @Email
END;