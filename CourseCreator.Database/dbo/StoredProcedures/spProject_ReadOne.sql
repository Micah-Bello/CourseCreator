CREATE PROCEDURE [dbo].[spProject_ReadOne]
	@Id int
AS
begin
	set nocount on;

	select [Id], [UserId], [Title], [Description], [IsPublished]
	from dbo.Project
	where @Id = Id;
end
