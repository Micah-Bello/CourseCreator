using Blazored.Toast.Services;
using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    public partial class SectionList
    {
        [Inject] public NavigationManager NavMan { get; set; }
        [Inject] public SectionDataService SectionData { get; set; }
        [Inject] public ProjectDataService ProjectData { get; set; }
        [Inject] public IToastService ToastService { get; set; }


        [Parameter]
        public int ProjectId { get; set; }

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

        public void NewSection()
        {
            NavMan.NavigateTo($"projects/add-new-section/{ProjectId}");
        }

        public async Task PublishProject()
        {
            project.IsPublished = true;
            await ProjectData.UpdatePublishStatus(project);
            ToastService.ShowSuccess("Project Published Successfully");
        }

        public async Task UnpublishProject()
        {
            project.IsPublished = false;
            await ProjectData.UpdatePublishStatus(project);
            ToastService.ShowToast(ToastLevel.Success, "Done");
        }
    }
}
