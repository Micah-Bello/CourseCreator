CREATE PROCEDURE [dbo].[spVideos_UpdateOrderNo]
	@Id int,
	@OrderNo int
AS
begin
	set nocount on;

	update dbo.Videos
	set OrderNo = @OrderNo
	where Id = @Id;
end
