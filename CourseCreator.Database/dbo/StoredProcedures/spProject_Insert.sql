CREATE PROCEDURE [dbo].[spProject_Insert]
	@UserId nvarchar(256),
	@Title nvarchar(256),
	@Description nvarchar(max),
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.Project(UserId, Title, [Description])
	values (@UserId, @Title, @Description);

	set @Id = SCOPE_IDENTITY();
end
