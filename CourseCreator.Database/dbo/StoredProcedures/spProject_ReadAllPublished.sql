CREATE PROCEDURE [dbo].[spProject_ReadAllPublished]
AS
begin
	set nocount on;

	select [Id], [UserId], [Title], [Description], IsPublished
	from dbo.Project
	where IsPublished = 1;
end
