CREATE PROCEDURE GetServicesByCategory(@categoryID INT)
AS
	BEGIN
	SELECT *
	FROM [Service]
	WHERE [Service].Category_ID=@categoryID
	RETURN
	END;