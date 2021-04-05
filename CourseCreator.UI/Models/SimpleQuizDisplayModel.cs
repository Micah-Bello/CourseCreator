using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class SimpleQuizDisplayModel
    {
        [Required]
        public string Question { get; set; }
        public bool IsOpinionQuestion { get; set; }
        public List<SimpleQuizOptionDisplayModel> Options { get; set; } = new List<SimpleQuizOptionDisplayModel>();
    }
}
