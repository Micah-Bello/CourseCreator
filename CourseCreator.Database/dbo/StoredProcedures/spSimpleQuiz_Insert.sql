CREATE PROCEDURE [dbo].[spSimpleQuiz_Insert]
	@SectionId int,
	@OrderNo int,
	@Question nvarchar(max),
	@IsOpinionQuestion bit,
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.SimpleQuiz(SectionId, OrderNo, Question, IsOpinionQuestion)
	values (@SectionId, @OrderNo, @Question, @IsOpinionQuestion);

	set @Id = SCOPE_IDENTITY();
end
