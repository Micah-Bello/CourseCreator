using CourseCreator.UI.Components.RenderFragments;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Models
{
    public class VideoDisplayModel : IContentDisplayable
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        public int OrderNo { get; set; }
        public string DisplayTitle => Title;

        public string ContentType => "Video";

        public RenderFragment Display()
        {
            return Video.VideoComponentFragment(this);
        }
    }
}
