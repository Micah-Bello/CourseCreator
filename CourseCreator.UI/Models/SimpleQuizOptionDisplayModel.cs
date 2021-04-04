using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class SimpleQuizOptionDisplayModel
    {
        [Required]
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
    }
}
