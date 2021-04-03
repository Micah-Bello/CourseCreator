CREATE TABLE [dbo].[SimpleQuiz]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SectionId] INT NOT NULL, 
    [OrderNo] INT NOT NULL, 
    [Question] NVARCHAR(MAX) NOT NULL, 
    [IsOpinionQuestion] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_SimpleQuiz_ToSection] FOREIGN KEY (SectionId) REFERENCES Section(Id),

)
