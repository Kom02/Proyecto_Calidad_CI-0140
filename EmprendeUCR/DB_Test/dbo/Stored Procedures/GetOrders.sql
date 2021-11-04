CREATE PROCEDURE [dbo].[GetOrders]
	@Email varchar(100),
	@State varchar(20)
AS
BEGIN
	SELECT @Email, @State

	SELECT [o].[Date_and_hour_of_creation], [o].[Client_Email], [o].[Delivery_date], [o].[Details], [o].[Entrepreneur_Email]
    FROM [Order] AS [o]
    JOIN (
        SELECT [o0].[Code_ID], [o0].[Entrepreneur_Email], [o0].[Category_ID], [o0].[Date_and_hour_of_creation], [o0].[Email], [o0].[Name], [o0].[Date_of_Change], [o0].[Quantity], [t].[Code_ID] AS [Code_ID0], [t].[Entrepreneur_Email] AS [Entrepreneur_Email0], [t].[Category_ID] AS [Category_ID0], [t].[Availability], [t].[Price], [t].[Product_Description], [t].[Product_Name], [t].[Price_per_hour], [t].[Service_Description], [t].[Service_Name], [t].[Discriminator], [s0].[Name] AS [Name0]
        FROM [Organized] AS [o0]
        INNER JOIN (
            SELECT [p].[Code_ID], [p].[Entrepreneur_Email], [p].[Category_ID], [p].[Availability], [p0].[Price], [p0].[Product_Description], [p0].[Product_Name], [s].[Price_per_hour], [s].[Service_Description], [s].[Service_Name], CASE
                WHEN [s].[Code_ID] IS NOT NULL THEN N'Service'
                WHEN [p0].[Code_ID] IS NOT NULL THEN N'Product'
            END AS [Discriminator]
            FROM [Product_Service] AS [p]
            LEFT JOIN [Product] AS [p0] ON (([p].[Code_ID] = [p0].[Code_ID]) AND ([p].[Entrepreneur_Email] = [p0].[Entrepreneur_Email])) AND ([p].[Category_ID] = [p0].[Category_ID])
            LEFT JOIN [Service] AS [s] ON (([p].[Code_ID] = [s].[Code_ID]) AND ([p].[Entrepreneur_Email] = [s].[Entrepreneur_Email])) AND ([p].[Category_ID] = [s].[Category_ID])
        ) AS [t] ON (([o0].[Code_ID] = [t].[Code_ID]) AND ([o0].[Entrepreneur_Email] = [t].[Entrepreneur_Email])) AND ([o0].[Category_ID] = [t].[Category_ID])
        INNER JOIN [Status] AS [s0] ON [o0].[Name] = [s0].[Name]
        WHERE [o0].[Name] LIKE @State
    ) AS [t0] ON ([o].[Date_and_hour_of_creation] = [t0].[Date_and_hour_of_creation]) AND ([o].[Client_Email] = [t0].[Email])
    WHERE [o].[Entrepreneur_Email] = @Email
    ORDER BY [o].[Date_and_hour_of_creation], [o].[Client_Email], [t0].[Code_ID], [t0].[Entrepreneur_Email], [t0].[Category_ID], [t0].[Date_and_hour_of_creation], [t0].[Email], [t0].[Name], [t0].[Code_ID0], [t0].[Entrepreneur_Email0], [t0].[Category_ID0], [t0].[Name0]

    RETURN
END;