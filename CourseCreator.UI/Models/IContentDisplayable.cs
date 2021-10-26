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
        RenderFragment DisplayComponent();
        RenderFragment AddComponent(NewBlockParameters parameters);

        int OrderNo { get; set; }
        string DisplayTitle { get; }
        string ContentType { get; }
    }
}
