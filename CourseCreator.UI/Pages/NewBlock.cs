using CourseCreator.Library;
using CourseCreator.UI.Models;
using CourseCreator.UI.Services;
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
        [Parameter]
        public int OrderNo { get; set; }

        private string selectedBlockType { get; set; }

        public IContentDisplayable BlockType => AvailableBlockTypes.Where(x => x.ContentType == selectedBlockType).FirstOrDefault();
        public List<IContentDisplayable> AvailableBlockTypes { get; set; }

        public NewBlockParameters Parameters => new NewBlockParameters { ProjectId = ProjectId, SectionId = SectionId, OrderNo = OrderNo };

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AvailableBlockTypes = Utility.GetAllContentTypes();
            selectedBlockType = AvailableBlockTypes.FirstOrDefault().ContentType;
        }
    }
}
