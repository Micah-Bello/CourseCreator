using CourseCreator.UI.Components.RenderFragments;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class MatchQuizDisplayModel : IContentDisplayable
    {
        [Required]
        public string Question { get; set; }
        public List<MatchQuizOptionDisplayModel> Options { get; set; } = new List<MatchQuizOptionDisplayModel>();
        public int OrderNo { get; set; }
        public string DisplayTitle => Question;
        public string ContentType => "Match Quiz";

        public RenderFragment Display()
        {
            return MatchQuiz.MatchQuizComponentFragment(this);
        }
    }
}
