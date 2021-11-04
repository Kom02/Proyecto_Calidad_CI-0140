CREATE VIEW ultimas_compras AS
SELECT TOP 30 Code_ID, Product_Name, Product_Description, Price, Entrepreneur_Email, Category_ID
FROM Product P JOIN compras_unicas C ON P.Code_ID = C.Product_ID;