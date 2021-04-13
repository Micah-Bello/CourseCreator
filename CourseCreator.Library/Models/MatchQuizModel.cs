using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class MatchQuizModel : IContentBlock
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int OrderNo { get; set; }
        public string DisplayTitle { get; set; }
        public string Question { get; set; }
        public Enums.BlockTypes Type { get; } = Enums.BlockTypes.MatchQuiz;
        public List<MatchQuizOptionModel> Options { get; set; } = new List<MatchQuizOptionModel>();
    }
}
