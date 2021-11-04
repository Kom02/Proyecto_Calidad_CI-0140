CREATE PROCEDURE GetServices(@service varchar(100))
AS
BEGIN
	SELECT *
	FROM [Service]
	WHERE [Service].[Service_Name] like  @service
	RETURN
END;