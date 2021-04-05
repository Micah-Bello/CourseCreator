CREATE PROCEDURE [dbo].[spSimpleQuiz_ReadOne]
	@Id int
AS
begin
	set nocount on;

	select [Id], [SectionId], [OrderNo], [Question], [IsOpinionQuestion]
	from dbo.SimpleQuiz
	where @Id = Id;
end
