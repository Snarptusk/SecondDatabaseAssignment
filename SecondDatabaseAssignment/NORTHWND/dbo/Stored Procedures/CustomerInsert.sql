CREATE PROCEDURE [dbo].[CustomerInsert]
	(@CustomerID   nchar (5)
	,@CompanyName  nchar (40)
	,@ContactName  nchar (30)
	,@Address	   nchar (60)
	,@City		   nchar (20))

	AS

INSERT INTO [dbo].[Customers]
	([CustomerID]
	,[CompanyName]
	,[ContactName]
	,[Address]
	,[City])

VALUES
	(@CustomerID
	,@CompanyName
	,@ContactName
	,@Address
	,@City)
