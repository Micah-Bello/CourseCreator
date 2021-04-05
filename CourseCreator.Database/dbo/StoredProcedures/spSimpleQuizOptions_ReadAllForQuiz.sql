CREATE PROCEDURE [dbo].[spSimpleQuizOptions_ReadAllForQuiz]
	@QuizId int
AS
begin
	set nocount on;

	select [Id], [QuizId], [Text], [IsAnswer]
	from dbo.SimpleQuizOptions
	where @QuizId = QuizId;
end
