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
    public class SimpleQuizDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public SimpleQuizDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateSimpleQuiz(SimpleQuizModel quiz)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("Question", quiz.Question);
                p.Add("IsOpinionQuestion", quiz.IsOpinionQuestion);
                p.Add("OrderNo", quiz.OrderNo);
                p.Add("SectionId", quiz.SectionId);
                p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

                _dataAccess.StartTransaction(SD.DB);

                await _dataAccess.SaveDataInTransaction("dbo.spSimpleQuiz_Insert", p);

                var quizId = p.Get<int>("Id");

                foreach (var option in quiz.Options)
                {
                    option.QuizId = quizId;

                    await _dataAccess.SaveDataInTransaction("dbo.spSimpleQuizOptions_Insert", option);
                }

                _dataAccess.CommitTransaction();
            }
            catch
            {
                _dataAccess.RollbackTransaction();

                throw;
            }
        }

        public async Task<List<SimpleQuizModel>> GetSectionQuizzes(int sectionId)
        {
            var rows = await _dataAccess.LoadData<SimpleQuizModel, dynamic>
                ("dbo.spSimpleQuiz_ReadAllForSection", new { SectionId = sectionId }, SD.DB);

            return rows;
        }

        public async Task<SimpleQuizModel> GetQuiz(int id)
        {
            try
            {
                _dataAccess.StartTransaction(SD.DB);

                var rows = await _dataAccess.LoadDataInTransaction<SimpleQuizModel, dynamic>
                    ("dbo.spSimpleQuiz_ReadOne", new { Id = id });

                var quiz = rows.FirstOrDefault();

                quiz.Options = await _dataAccess.LoadDataInTransaction<SimpleQuizOptionModel, dynamic>
                    ("dbo.spSimpleQuizOptions_ReadAllForQuiz", new { QuizId = quiz.Id });

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
