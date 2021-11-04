CREATE VIEW [OrderNotificationClient] AS
SELECT o.Client_Email,o.Date_and_hour_of_creation,o.[State],u.[Name],o.[Date_and_hour_of_State_Changed],o.[view]
FROM [Order] o join [User] u on o.Entrepreneur_Email = u.Email
WHERE (o.State = 'Rechazado' or o.State = 'Aceptado') and o.[view] = 0 ;