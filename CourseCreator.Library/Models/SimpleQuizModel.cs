using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class SimpleQuizModel : CourseContentBase
    {
        public string Question { get; set; }
        public bool IsOpinionQuestion { get; set; }
        public List<SimpleQuizOptionModel> Options { get; set; } = new List<SimpleQuizOptionModel>();
        
    }
}
