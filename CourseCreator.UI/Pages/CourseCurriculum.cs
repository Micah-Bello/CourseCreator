using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    public partial class CourseCurriculum
    {
        [Parameter]
        public int ProjectId { get; set; }
        [Inject] 
        public SectionDataService SectionData { get; set; }
        [Inject] 
        public ProjectDataService ProjectData { get; set; }

        private List<SectionModel> sections;
        private ProjectModel project;

        private bool notFound = false;

        protected override async Task OnInitializedAsync()
        {
            project = await ProjectData.GetProjectById(ProjectId);

            if (project is null)
            {
                notFound = true;
            }

            sections = await SectionData.GetAllSections(ProjectId);
        }


    }
}
