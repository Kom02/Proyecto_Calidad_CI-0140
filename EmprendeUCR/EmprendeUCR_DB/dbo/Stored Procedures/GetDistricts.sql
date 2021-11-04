CREATE PROCEDURE GetDistricts(@canton varchar(15))
AS
BEGIN
	SELECT Province_Name, Canton_Name, Name
	FROM District
	WHERE Canton_Name = @canton
	RETURN
END;