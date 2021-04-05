CREATE PROCEDURE [dbo].[spSimpleQuiz_ReadAllForSection]
	@SectionId int
AS
begin
	set nocount on;

	select [Id], [SectionId], [OrderNo], [Question], [IsOpinionQuestion]
	from dbo.SimpleQuiz
	where @SectionId = SectionId;
end
