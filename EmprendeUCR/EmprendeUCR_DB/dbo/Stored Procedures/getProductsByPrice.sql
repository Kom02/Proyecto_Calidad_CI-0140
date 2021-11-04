CREATE PROCEDURE getProductsByPrice @searchType int
AS
BEGIN
	IF @searchType = 1
		SELECT * FROM Product
		ORDER BY Product.Price DESC
		
	ELSE IF @searchType = 2
		SELECT * FROM Product
		ORDER BY Product.Price ASC	
END;