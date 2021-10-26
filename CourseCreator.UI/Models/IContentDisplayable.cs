using CourseCreator.Library.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public interface IContentDisplayable
    {
        RenderFragment Display();

        int OrderNo { get; set; }
        string DisplayTitle { get; }
        string ContentType { get; }
    }
}
