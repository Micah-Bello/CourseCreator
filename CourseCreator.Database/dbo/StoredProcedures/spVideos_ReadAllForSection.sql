CREATE PROCEDURE [dbo].[spVideos_ReadAllForSection]
	@SectionId int
AS
begin
	set nocount on;

	select [Id], [SectionId], [OrderNo], Title, VideoUrl
	from dbo.Videos
	where @SectionId = SectionId;
end
