CREATE PROCEDURE [dbo].[spSimpleQuiz_UpdateOrderNo]
	@Id int,
	@OrderNo int
AS
begin
	set nocount on;

	update dbo.SimpleQuiz
	set OrderNo = @OrderNo
	where Id = @Id;
end
