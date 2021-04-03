using CourseCreator.Library.DataAccess;
using CourseCreator.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Data
{
    public class SimpleQuizDataService
    {
        private readonly ISqlDataAccess _dataAcess;

        public SimpleQuizDataService(ISqlDataAccess dataAcess)
        {
            _dataAcess = dataAcess;
        }

        public async Task CreateSimpleQuiz(SimpleQuizModel quiz)
        {
            await _dataAcess.SaveData("dbo.spSimpleQuiz_Insert", quiz, SD.DB);
        }
    }
}
