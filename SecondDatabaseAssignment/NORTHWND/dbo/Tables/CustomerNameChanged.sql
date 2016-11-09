CREATE TABLE [dbo].[CustomerContactNameChanges](
    [ContactNameChangeID] [int] IDENTITY(1,1) NOT NULL,
    [ContactID] TEXT NOT NULL,
    [OldName] [text] NOT NULL,
    [NewName] [text] NOT NULL,
    [ChangedDate] [datetime] NOT NULL,
    [UserId] [int] NOT NULL,
    PRIMARY KEY CLUSTERED 
    (
        [ContactNameChangeID] ASC
    )
)

