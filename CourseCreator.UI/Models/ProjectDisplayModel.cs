using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class ProjectDisplayModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
