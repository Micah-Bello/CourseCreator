CREATE PROCEDURE [dbo].[spMatchQuiz_ReadAllForSection]
	@SectionId int
AS
begin
	set nocount on;

	select [Id], [SectionId], [OrderNo], [Question]
	from dbo.MatchQuiz
	where @SectionId = SectionId;
end
