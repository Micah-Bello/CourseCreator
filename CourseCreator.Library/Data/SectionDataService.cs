using CourseCreator.Library.DataAccess;
using CourseCreator.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Data
{
    public class SectionDataService
    {
        private readonly ISqlDataAccess _dataAcess;

        public SectionDataService(ISqlDataAccess dataAcess)
        {
            _dataAcess = dataAcess;
        }

        public async Task CreateSection(SectionModel section)
        {
            await _dataAcess.SaveData("dbo.spSection_Insert", section, SD.DB);
        }
    }
}
