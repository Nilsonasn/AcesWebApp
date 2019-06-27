CREATE TABLE [dbo].[Students] (
    [classID]       NVARCHAR (50)  NOT NULL,
    [githubUsrName] NVARCHAR (50)  NOT NULL,
    [githubEmail]   NVARCHAR (50)  NOT NULL,
    [name]          NVARCHAR (255) NULL,
    CONSTRAINT [FK_Students_Classroom] FOREIGN KEY ([classID]) REFERENCES [dbo].[Classroom] ([classID])
);

