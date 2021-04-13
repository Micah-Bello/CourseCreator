CREATE PROCEDURE [dbo].[spMatchQuiz_Insert]
	@SectionId int,
	@OrderNo int,
	@Question nvarchar(500),
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.MatchQuiz(SectionId, OrderNo, Question)
	values (@SectionId, @OrderNo, @Question);

	set @Id = SCOPE_IDENTITY();
end
