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

        public async Task<int> CreateProject(ProjectModel project)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Title", project.Title);
            p.Add("Description", project.Description);
            p.Add("UserId", project.UserId);
            p.Add("IsPublished", project.IsPublished);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spProject_Insert", p, SD.DB);

            return p.Get<int>("Id");
        }

        public async Task UpdatePublishStatus(ProjectModel project)
        {
            await _dataAccess.SaveData("dbo.spProject_UpdatePublishedStatus", new { Id = project.Id, IsPublished = project.IsPublished }, SD.DB);
        }

        public async Task<List<ProjectModel>> GetPublishedProjects()
        {
            var rows = await _dataAccess.LoadData<ProjectModel, dynamic>
                ("dbo.spProject_ReadAllPublished", new { }, SD.DB);

            return rows;
        }

        public async Task<List<ProjectModel>> GetUserProjects(string userId)
        {
            var rows = await _dataAccess.LoadData<ProjectModel, dynamic>
                ("dbo.spProject_ReadAllForUser", new { UserId = userId }, SD.DB);

            return rows;
        }

        public async Task<ProjectModel> GetProjectById(int id)
        {
            var rows = await _dataAccess.LoadData<ProjectModel, dynamic>
                ("dbo.spProject_ReadOne", new { Id = id }, SD.DB);

            return rows.FirstOrDefault();
        }
    }
}
