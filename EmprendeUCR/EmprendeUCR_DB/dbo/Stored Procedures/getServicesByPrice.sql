
CREATE PROCEDURE getServicesByPrice @searchType int
AS
BEGIN
	IF @searchType = 1
	SELECT * FROM [Service]
	ORDER BY [Service].Price_per_hour DESC

	ELSE IF @searchType = 2
	SELECT * FROM [Service]
	ORDER BY [Service].Price_per_hour ASC

END;