using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    [Authorize]
    public partial class NewSection
    {
        [Inject]
        public SectionDataService SectionData { get; set; }
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Parameter]
        public int ProjectId { get; set; }

        private SectionDisplayModel section = new SectionDisplayModel();

        private async Task CreateNewSection()
        {
            SectionModel sectionToSave = new SectionModel
            {
                ProjectId = ProjectId,
                Title = section.Title,
                Description = section.Description
            };

            var id = await SectionData.CreateSection(sectionToSave);

            NavMan.NavigateTo($"/projects/{ProjectId}");
        }

        private void OnCancelClick()
        {
            NavMan.NavigateTo($"/projects/{ProjectId}");
        }
    }
}
