using CourseCreator.UI.Components.RenderFragments;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class SimpleQuizDisplayModel : IContentDisplayable
    {
        [Required]
        public string Question { get; set; }
        public bool IsOpinionQuestion { get; set; }
        public int OrderNo { get; set; }
        public string DisplayTitle => Question;
        public List<SimpleQuizOptionDisplayModel> Options { get; set; } = new List<SimpleQuizOptionDisplayModel>();

        public string ContentType => "Simple Quiz";

        public RenderFragment DisplayComponent()
        {
            return SimpleQuiz.SimpleQuizComponentFragment(this);
        }

        public RenderFragment AddComponent(NewBlockParameters parameters)
        {
            return SimpleQuiz.AddSimpleQuizComponentFragment(parameters);
        }
    }
}
