CREATE PROCEDURE [dbo].[spSimpleQuiz_Insert]
	@Id int,
	@SectionId int,
	@OrderNo int,
	@Question nvarchar(max),
	@IsOpinionQuestion bit
AS
begin
	set nocount on;

	insert into dbo.SimpleQuiz(SectionId, OrderNo, Question, IsOpinionQuestion)
	values (@SectionId, @OrderNo, @Question, @IsOpinionQuestion);
end
