CREATE PROCEDURE GetProductsByCategory(@categoryID INT)
AS
	BEGIN
	SELECT *
	FROM Product
	WHERE Product.Category_ID=@categoryID
	RETURN
	END;