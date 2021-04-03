CREATE PROCEDURE [dbo].[spSection_Insert]
	@Id int,
	@ProjectId int,
	@Title nvarchar(256),
	@Description nvarchar(max)
AS
begin
	set nocount on;

	insert into dbo.Section(ProjectId, Title, [Description])
	values (@ProjectId, @Title, @Description);
end
