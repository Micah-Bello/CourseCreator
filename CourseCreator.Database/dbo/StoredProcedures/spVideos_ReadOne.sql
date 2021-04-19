CREATE PROCEDURE [dbo].[spVideos_ReadOne]
	@Id int
AS
begin
	set nocount on;

	select [Id], [SectionId], [OrderNo], Title, VideoUrl
	from dbo.Videos
	where @Id = Id;
end
