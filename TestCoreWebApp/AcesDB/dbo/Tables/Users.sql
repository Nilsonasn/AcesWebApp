CREATE TABLE [dbo].[Users] (
    [id]                  NVARCHAR (50)      NOT NULL,
    [Username]            NVARCHAR (50)      NOT NULL,
    [FirstName]           NVARCHAR (50)      NOT NULL,
    [LastName]            NVARCHAR (50)      NOT NULL,
    [IsEnabled]           BIT                NOT NULL,
    [CreatedDateUtc]      DATETIMEOFFSET (7) NOT NULL,
    [LastLoggedInDateUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC)
);

