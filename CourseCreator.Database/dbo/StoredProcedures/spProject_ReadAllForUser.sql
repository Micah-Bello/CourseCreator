CREATE PROCEDURE [dbo].[spProject_ReadAllForUser]
	@UserId nvarchar(256)
AS
begin
	set nocount on;

	select [Id], [UserId], [Title], [Description], [IsPublished]
	from dbo.Project
	where UserId = @UserId;
end
