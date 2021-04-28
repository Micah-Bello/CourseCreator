CREATE PROCEDURE [dbo].[spProject_Insert]
	@UserId nvarchar(256),
	@Title nvarchar(256),
	@Description nvarchar(max),
	@IsPublished bit,
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.Project(UserId, Title, [Description], IsPublished)
	values (@UserId, @Title, @Description, @IsPublished);

	set @Id = SCOPE_IDENTITY();
end
