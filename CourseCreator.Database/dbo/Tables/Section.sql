CREATE TABLE [dbo].[Section]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectId] INT NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Section_ToProject] FOREIGN KEY (ProjectId) REFERENCES Project(Id),
)
