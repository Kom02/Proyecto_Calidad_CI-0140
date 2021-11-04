CREATE VIEW [OrderNotificationEntrepeneurs] AS
SELECT o.Client_Email,o.Date_and_hour_of_creation, o.[State],o.Entrepreneur_Email,u.[Name],o.[Date_and_hour_of_State_Changed]
FROM [Order] o join [User] u on o.Client_Email = u.Email
WHERE o.State = 'Pendiente de revision';