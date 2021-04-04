CREATE PROCEDURE [dbo].[spProject_ReadOne]
	@Id int
AS
begin
	set nocount on;

	select [Id], [UserId], [Title], [Description]
	from dbo.Project
	where @Id = Id;
end
