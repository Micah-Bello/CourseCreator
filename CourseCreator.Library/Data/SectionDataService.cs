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
    public class SectionDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public SectionDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> CreateSection(SectionModel section)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Title", section.Title);
            p.Add("Description", section.Description);
            p.Add("ProjectId", section.ProjectId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spSection_Insert", p, SD.DB);

            return p.Get<int>("Id");
        }

        public async Task<List<SectionModel>> GetAllSections(int projectId)
        {
            var rows = await _dataAccess.LoadData<SectionModel, dynamic>
                ("dbo.spSection_ReadAllForProject", new { ProjectId = projectId }, SD.DB);

            return rows;
        }
    }
}
