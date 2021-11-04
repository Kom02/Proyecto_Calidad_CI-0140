CREATE TABLE [dbo].[Has_Keyword] (
    [Product_ID]                 INT           NOT NULL,
    [Product_Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Product_Category_ID]        INT           NOT NULL,
    [Keyword_ID]                 INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Keyword_ID] ASC, [Product_ID] ASC, [Product_Entrepreneur_Email] ASC, [Product_Category_ID] ASC),
    FOREIGN KEY ([Keyword_ID]) REFERENCES [dbo].[Keyword] ([Id]),
    FOREIGN KEY ([Product_ID], [Product_Entrepreneur_Email], [Product_Category_ID]) REFERENCES [dbo].[Product] ([Code_ID], [Entrepreneur_Email], [Category_ID])
);


GO
CREATE TRIGGER Keyword_Product_Restriction
ON Has_Keyword INSTEAD OF INSERT
AS
BEGIN
	DECLARE @Product_ID INT
	DECLARE @Product_Entrepreneur_Email VARCHAR(100)
	DECLARE @Product_Category_ID INT
	DECLARE @Keyword_ID INT
	DECLARE @AmountOfKeywordsAssignedToProduct INT

    DECLARE c CURSOR LOCAL FOR
    SELECT i.Product_ID, i.Product_Entrepreneur_Email, i.Product_Category_ID, i.Keyword_ID
    FROM inserted i
    OPEN c
    FETCH NEXT FROM c INTO @Product_ID, @Product_Entrepreneur_Email, @Product_Category_ID, @Keyword_ID
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @AmountOfKeywordsAssignedToProduct = COUNT(Keyword_ID)
        FROM Has_Keyword
        WHERE Product_ID = @Product_ID AND Product_Entrepreneur_Email = @Product_Entrepreneur_Email AND Product_Category_ID = @Product_Category_ID
		IF @AmountOfKeywordsAssignedToProduct < 5
        BEGIN
            INSERT INTO Has_Keyword 
            VALUES(@Product_ID, @Product_Entrepreneur_Email, @Product_Category_ID, @Keyword_ID);
        END
        ELSE
        BEGIN 
            print('Un producto no puede tener más de 5 keywords asignados')
        END
        FETCH NEXT FROM c INTO @Product_ID, @Product_Entrepreneur_Email, @Product_Category_ID, @Keyword_ID
    END
    CLOSE c;
    DEALLOCATE c;
END