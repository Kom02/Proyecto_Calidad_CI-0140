CREATE PROCEDURE GetDistricts(@canton varchar(15))
AS
BEGIN
	SELECT District.Name
	FROM District
	WHERE District.Canton_Name = @canton
	RETURN
END;