CREATE PROCEDURE [dbo].[spMatchQuiz_UpdateOrderNo]
	@Id int,
	@OrderNo int
AS
begin
	set nocount on;

	update dbo.MatchQuiz
	set OrderNo = @OrderNo
	where Id = @Id;
end
