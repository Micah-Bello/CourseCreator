﻿CREATE TABLE [dbo].[MatchQuiz]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	SectionId INT NOT NULL,
	OrderNo INT NOT NULL,
	Question NVARCHAR(500) NOT NULL, 
    CONSTRAINT [FK_MatchQuiz_ToSection] FOREIGN KEY (SectionId) REFERENCES Section(Id)
)
