CREATE TRIGGER [CustomerUpdateTrigger]
ON [dbo].[Customers]
FOR UPDATE

AS

BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[CustomerContactNameChanges]
	([ContactID], [OldName], [NewName], [ChangedDate], [UserId])

	SELECT i.[CustomerID], d.[ContactName], i.[ContactName], GETDATE(), USER_ID()
            FROM inserted i
              INNER JOIN deleted d ON i.[CustomerID]=d.[CustomerID]
            WHERE d.[ContactName] <> i.[ContactName]
END
