CREATE PROCEDURE [dbo].[GetPendingOrders]
AS
BEGIN
	select o.Date_and_hour_of_creation,o.Client_Email,u.[Name],o.Delivery_date,o.Details,o.Entrepreneur_Email
	from [Order] o JOIN Client c on o.Client_Email = c.User_Email
	JOIN Members m on m.User_Email = c.User_Email
	JOIN [User] u on u.Email = m.User_Email
	RETURN
END;