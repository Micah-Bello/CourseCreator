using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    public partial class NewBlock
    {
        [Parameter]
        public int SectionId { get; set; }
        [Parameter]
        public int ProjectId { get; set; }
    }
}
