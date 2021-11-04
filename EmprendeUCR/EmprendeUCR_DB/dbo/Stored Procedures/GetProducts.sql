CREATE PROCEDURE GetProducts(@product varchar(100))
AS
BEGIN
	SELECT *
	FROM Product
	WHERE Product.Product_Name like  @product
	RETURN
END;