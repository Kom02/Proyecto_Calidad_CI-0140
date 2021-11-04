CREATE PROCEDURE GetProductsRestricted(@input VARCHAR(100),@category INT)
AS
	BEGIN
		SELECT *
		FROM Product
		WHERE Product.Product_Name like  @input AND Product.Category_ID=@category
	END;