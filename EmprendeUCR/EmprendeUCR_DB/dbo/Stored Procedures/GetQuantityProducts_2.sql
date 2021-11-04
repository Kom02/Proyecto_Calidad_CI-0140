CREATE PROCEDURE [dbo].[GetQuantityProducts]  
@quantity INT OUTPUT 

AS BEGIN 
	SELECT @quantity = count(p.Code_ID) 
	FROM Product p;
END