using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class MatchQuizOptionModel
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string LeftOption { get; set; }
        public string RightOption { get; set; }
    }
}
