CREATE PROCEDURE [dbo].[products_based_last_purchases] @User_Email varchar(100)
AS
IF  EXISTS (SELECT * FROM Likes WHERE Likes.Members_Email = @User_Email)
	SELECT LP.Code_ID, LP.Product_Name, LP.Product_Description, LP.Price, LP.Entrepreneur_Email, LP.Category_ID
	FROM Likes L JOIN Last_Purchases LP ON L.Category_Id = LP.Category_ID
	WHERE L.Members_Email = @User_Email;
ELSE
	SELECT * FROM Last_Purchases;