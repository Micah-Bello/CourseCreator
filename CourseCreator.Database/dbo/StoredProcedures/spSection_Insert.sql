CREATE PROCEDURE [dbo].[spSection_Insert]
	@ProjectId int,
	@Title nvarchar(256),
	@Description nvarchar(max),
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.Section(ProjectId, Title, [Description])
	values (@ProjectId, @Title, @Description);

	set @Id = SCOPE_IDENTITY();
end
