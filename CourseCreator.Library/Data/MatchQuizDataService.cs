using CourseCreator.Library.DataAccess;
using CourseCreator.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Data
{
    public class MatchQuizDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public MatchQuizDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateMatchQuiz(MatchQuizModel quiz)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("Question", quiz.Question);
                p.Add("OrderNo", quiz.OrderNo);
                p.Add("SectionId", quiz.SectionId);
                p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

                _dataAccess.StartTransaction(SD.DB);

                await _dataAccess.SaveDataInTransaction("dbo.spMatchQuiz_Insert", p);

                var quizId = p.Get<int>("Id");

                foreach (var option in quiz.Options)
                {
                    option.QuizId = quizId;

                    var op = new
                    {
                        option.Id,
                        option.QuizId,
                        option.LeftOption,
                        option.RightOption
                    };

                    await _dataAccess.SaveDataInTransaction("dbo.spMatchQuizOptions_Insert", op);
                }

                _dataAccess.CommitTransaction();
            }
            catch
            {
                _dataAccess.RollbackTransaction();

                throw;
            }
        }

        public async Task<List<MatchQuizModel>> GetSectionQuizzes(int sectionId)
        {
            var rows = await _dataAccess.LoadData<MatchQuizModel, dynamic>
                ("dbo.spMatchQuiz_ReadAllForSection", new { SectionId = sectionId }, SD.DB);

            return rows;
        }

        public async Task<MatchQuizModel> GetQuiz(int id)
        {
            try
            {
                _dataAccess.StartTransaction(SD.DB);

                var rows = await _dataAccess.LoadDataInTransaction<MatchQuizModel, dynamic>
                    ("dbo.spMatchQuiz_ReadOne", new { Id = id });

                var quiz = rows.FirstOrDefault();

                quiz.Options = await _dataAccess.LoadDataInTransaction<MatchQuizOptionModel, dynamic>
                    ("dbo.spMatchQuizOptions_ReadAllForQuiz", new { QuizId = quiz.Id });

                _dataAccess.CommitTransaction();

                return quiz;
            }
            catch
            {
                _dataAccess.RollbackTransaction();

                throw;
            }
        }
    }
}
