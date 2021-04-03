using CourseCreator.Library.DataAccess;
using CourseCreator.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Data
{
    public class SimpleQuizOptionDataService
    {
        private readonly ISqlDataAccess _dataAcess;

        public SimpleQuizOptionDataService(ISqlDataAccess dataAcess)
        {
            _dataAcess = dataAcess;
        }

        public async Task CreateSimpleQuizOption(SimpleQuizOptionModel option)
        {
            await _dataAcess.SaveData("dbo.spSimpleQuizOptions_Insert", option, SD.DB);
        }
    }
}
