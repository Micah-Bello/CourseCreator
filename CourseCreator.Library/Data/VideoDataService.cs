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
    public class VideoDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public VideoDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateVideo(VideoModel video)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Title", video.Title);
            p.Add("VideoUrl", video.VideoUrl);
            p.Add("OrderNo", video.OrderNo);
            p.Add("SectionId", video.SectionId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spVideos_Insert", p, SD.DB);
        }

        public async Task<List<VideoModel>> GetSectionVideos(int sectionId)
        {
            var rows = await _dataAccess.LoadData<VideoModel, dynamic>
                ("dbo.spVideos_ReadAllForSection", new { SectionId = sectionId }, SD.DB);

            return rows;
        }

        public async Task<VideoModel> GetVideo(int id)
        {
            var rows = await _dataAccess.LoadData<VideoModel, dynamic>
                ("dbo.spVideos_ReadOne", new { Id = id }, SD.DB);

            return rows.FirstOrDefault();
        }

        public async Task UpdateVideoOrderNo(VideoModel video)
        {
            var p = new
            {
                Id = video.Id,
                OrderNo = video.OrderNo
            };
            await _dataAccess.SaveData("dbo.spVideos_UpdateOrderNo", p, SD.DB);
        }
    }
}
