using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class VideoModel : CourseContentBase
    {
        public string Title { get; set; }
        public string VideoUrl { get; set; }
    }
}
