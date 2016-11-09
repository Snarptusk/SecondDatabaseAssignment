CREATE PROCEDURE [dbo].[UpdateProductPrice]
	(@ProductName		nchar (40)
	,@UnitPriceChange	nchar (30))

	AS

UPDATE [dbo].[Products]
	SET [UnitPrice] = [UnitPrice] + @UnitPriceChange
	WHERE [ProductName] = @ProductName