CREATE PROCEDURE getRecommendedProducts @User_Email varchar(100)
AS
IF  EXISTS (SELECT * FROM Likes WHERE Likes.Members_Email = @User_Email)
	SELECT TOP 30 P.Code_ID, P.Product_Name, P.Product_Description, P.Price, P.Entrepreneur_Email, P.Category_ID
	FROM Category C JOIN Likes L ON L.Category_Id = C.Id JOIN Product P ON P.Category_ID = C.Id
	WHERE L.Members_Email = @User_Email;
ELSE
	SELECT TOP 30 * FROM Product ORDER BY NEWID();