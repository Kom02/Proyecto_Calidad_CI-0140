/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Role AS TARGET
USING (VALUES
	(1, 'Administrator'),
	(2, 'Client'),
	(3, 'Entrepreneur')
)
AS Source ([Id], Type)
ON TARGET.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, Type)
VALUES (Id, Type);

MERGE INTO Permission AS TARGET
USING (VALUES
       (1, 'Permitir alianzas con otros emprendedores'),
       (2, 'Permitir revisar los reportes de los clientes')
)
AS Source ([Id], Description)
ON TARGET.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, Description)
VALUES (Id, Despription);
