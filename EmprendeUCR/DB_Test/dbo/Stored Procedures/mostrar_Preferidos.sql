CREATE PROCEDURE mostrar_Preferidos @User_Email varchar(100)
AS
SELECT TOP 30 Code_ID, Product_Name, Product_Description, Price, Entrepreneur_Email
FROM Category JOIN Likes ON Likes.Category_Id = Category.Id JOIN Product ON Product.Category_ID = Category.Id
WHERE Likes.Members_Email = @User_Email;