CREATE PROCEDURE [dbo].[spSection_ReadAllForProject]
	@ProjectId int
AS
begin
	set nocount on;

	select [Id], [ProjectId], [Title], [Description]
	from dbo.Section
	where @ProjectId = ProjectId;
end
