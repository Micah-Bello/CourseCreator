using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class SimpleQuizModel
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Question { get; set; }
        public bool IsOpinionQuestion { get; set; }
        public List<SimpleQuizOptionModel> Options { get; set; }
    }
}
