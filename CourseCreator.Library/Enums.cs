using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.Library
{
    public static class Enums
    {
        public enum BlockTypes
        {
            SimpleQuiz,
            MatchQuiz,
            Video
        }

        public static Dictionary<int, string> BlockTypeNames = new Dictionary<int, string>
        {
            { (int) BlockTypes.SimpleQuiz, "Quiz" },
            { (int) BlockTypes.MatchQuiz, "Match Quiz" },
            { (int) BlockTypes.Video, "Video" }
        };
    }
}
