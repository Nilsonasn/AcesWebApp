CREATE TABLE [dbo].[Classroom] (
    [classID]   NVARCHAR (50) NOT NULL,
    [orgName]   NVARCHAR (50) NOT NULL,
    [className] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Classroom] PRIMARY KEY CLUSTERED ([classID] ASC)
);

