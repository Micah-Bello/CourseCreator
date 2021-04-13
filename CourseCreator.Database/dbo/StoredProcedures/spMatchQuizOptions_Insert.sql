CREATE PROCEDURE [dbo].[spMatchQuizOptions_Insert]
	@Id int,
	@QuizId int,
	@LeftOption nvarchar(500),
	@RightOption nvarchar(500)
AS
begin
	set nocount on;

	insert into dbo.MatchQuizOptions(QuizId, LeftOption, RightOption)
	values(@QuizId, @LeftOption, @RightOption);
end
