CREATE PROCEDURE [dbo].[spProject_Insert]
	@Id int,
	@UserId nvarchar(256),
	@Title nvarchar(256),
	@Description nvarchar(max)
AS
begin
	set nocount on;

	insert into dbo.Project(UserId, Title, [Description])
	values (@UserId, @Title, @Description);
end
