using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public class CourseContentBase
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int OrderNo { get; set; }
    }
}
