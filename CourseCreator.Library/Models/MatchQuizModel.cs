using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class MatchQuizModel : CourseContentBase
    {
        public string Question { get; set; }
        public List<MatchQuizOptionModel> Options { get; set; } = new List<MatchQuizOptionModel>();
    }
}
