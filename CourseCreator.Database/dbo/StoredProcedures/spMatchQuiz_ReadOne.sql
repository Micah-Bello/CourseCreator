CREATE PROCEDURE [dbo].[spMatchQuiz_ReadOne]
	@Id int
AS
begin
	set nocount on;

	select [Id], [SectionId], [OrderNo], [Question]
	from dbo.MatchQuiz
	where @Id = Id;
end
