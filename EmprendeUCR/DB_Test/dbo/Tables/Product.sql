CREATE TABLE [dbo].[Product] (
    [Code_ID]             INT           NOT NULL,
    [Product_Name]        VARCHAR (100) NOT NULL,
    [Product_Description] VARCHAR (220) NULL,
    [Price]               INT           NOT NULL,
    [Entrepreneur_Email]  VARCHAR (100) NOT NULL,
    [Category_ID]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [index_Product_Name]
    ON [dbo].[Product]([Product_Name] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_product_price]
    ON [dbo].[Product]([Price] ASC, [Product_Name] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_productos_emprendedor_por_categoria]
    ON [dbo].[Product]([Category_ID] ASC)
    INCLUDE([Entrepreneur_Email]);

