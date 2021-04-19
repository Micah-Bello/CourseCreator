CREATE PROCEDURE [dbo].[spVideos_Insert]
	@SectionId int,
	@OrderNo int,
	@Title nvarchar(256),
	@VideoUrl nvarchar(256),
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.Videos(SectionId, OrderNo, Title, VideoUrl)
	values (@SectionId, @OrderNo, @Title, @VideoUrl);

	set @Id = SCOPE_IDENTITY();
end
