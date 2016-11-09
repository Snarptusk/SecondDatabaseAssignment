CREATE PROCEDURE [dbo].[ProductInsert]
	(@ProductName	nchar (40)
	,@UnitPrice		nchar (30)
	,@Discontinued	nchar (60))

	AS

INSERT INTO [dbo].[Products]
	([ProductName]
	,[UnitPrice]
	,[Discontinued])

VALUES
	(@ProductName
	,@UnitPrice
	,@Discontinued)
