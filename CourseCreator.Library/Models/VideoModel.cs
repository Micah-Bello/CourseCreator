using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class VideoModel : IContentBlock
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int OrderNo { get; set; }
        public string DisplayTitle { get; set; }
        public Enums.BlockTypes Type { get; } = Enums.BlockTypes.Video;
        public string Title { get; set; }
        public string VideoUrl { get; set; }
    }
}
