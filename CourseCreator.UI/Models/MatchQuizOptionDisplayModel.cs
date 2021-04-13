using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class MatchQuizOptionDisplayModel
    {
        [Required]
        public string LeftOption { get; set; }
        [Required]
        public string RightOption { get; set; }
    }
}
