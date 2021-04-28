CREATE PROCEDURE [dbo].[spProject_UpdatePublishedStatus]
	@Id int,
	@IsPublished bit
AS
begin
	set nocount on;

	update dbo.Project
	set IsPublished = @IsPublished
	where Id = @Id;
end