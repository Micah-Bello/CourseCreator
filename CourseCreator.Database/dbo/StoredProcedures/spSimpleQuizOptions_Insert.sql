CREATE PROCEDURE [dbo].[spSimpleQuizOptions_Insert]
	@Id int,
	@QuizId int,
	@Text nvarchar(256),
	@IsAnswer bit
AS
begin
	set nocount on;

	insert into dbo.SimpleQuizOptions(QuizId, [Text], IsAnswer)
	values (@QuizId, @Text, @IsAnswer);
end