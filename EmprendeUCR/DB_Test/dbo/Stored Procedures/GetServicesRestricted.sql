CREATE PROCEDURE GetServicesRestricted(@input VARCHAR(100),@category INT)
AS
	BEGIN
		SELECT *
		FROM [Service]
		WHERE [Service].[Service_Name] like  @input AND [Service].Category_ID=@category
	END;