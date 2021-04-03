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
    public class ProjectDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public ProjectDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateProject(ProjectModel project)
        {
            await _dataAccess.SaveData("dbo.spProject_Insert", project, SD.DB);
        }
    }
}
