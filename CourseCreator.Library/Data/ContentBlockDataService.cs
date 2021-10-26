using CourseCreator.Library.DataAccess;
using CourseCreator.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Data
{
    public class ContentBlockDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public ContentBlockDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task UpdateOrderNo(List<CourseContentBase> blocks)
        {
            try
            {
                _dataAccess.StartTransaction(SD.DB);

                foreach (var block in blocks)
                {
                    var p = new
                    {
                        Id = block.Id,
                        OrderNo = block.OrderNo
                    };

                    if (block.GetType() == typeof(SimpleQuizModel))
                    {
                        await _dataAccess.SaveData("dbo.spSimpleQuiz_UpdateOrderNo", p, SD.DB);
                    }
                    if (block.GetType() == typeof(MatchQuizModel))
                    {
                        await _dataAccess.SaveData("dbo.spMatchQuiz_UpdateOrderNo", p, SD.DB);
                    }
                    if (block.GetType() == typeof(VideoModel))
                    {
                        await _dataAccess.SaveData("dbo.spVideos_UpdateOrderNo", p, SD.DB);
                    }
                }

                _dataAccess.CommitTransaction();
            }
            catch
            {
                _dataAccess.RollbackTransaction();

                throw;
            }
        }
    }
}
