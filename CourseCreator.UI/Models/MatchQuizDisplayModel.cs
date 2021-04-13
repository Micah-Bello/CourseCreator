using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class MatchQuizDisplayModel
    {
        [Required]
        public string Question { get; set; }
        public List<MatchQuizOptionDisplayModel> Options { get; set; } = new List<MatchQuizOptionDisplayModel>();
    }
}
