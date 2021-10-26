using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class SimpleQuizComponent
    {
        [Parameter]
        public SimpleQuizDisplayModel Quiz { get; set; }
    }
}
