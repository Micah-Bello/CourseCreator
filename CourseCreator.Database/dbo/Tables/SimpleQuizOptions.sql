CREATE TABLE [dbo].[SimpleQuizOptions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuizId] INT NOT NULL, 
    [Text] NVARCHAR(256) NOT NULL, 
    [IsAnswer] BIT NOT NULL, 
    CONSTRAINT [FK_SimpleQuizOptions_ToSimpleQuiz] FOREIGN KEY (QuizId) REFERENCES SimpleQuiz(Id),

)
