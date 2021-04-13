CREATE PROCEDURE [dbo].[spMatchQuizOptions_ReadAllForQuiz]
	@QuizId int
AS
begin
	set nocount on;

	select [Id], [QuizId], [LeftOption], [RightOption]
	from dbo.MatchQuizOptions
	where @QuizId = QuizId;
end
