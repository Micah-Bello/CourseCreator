using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Library.Models
{
    public interface IContentBlock
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int OrderNo { get; set; }
        public string Type { get; }
    }
}
