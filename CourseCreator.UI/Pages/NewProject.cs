using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    [Authorize]
    public partial class NewProject
    {
        [Inject]
        public ProjectDataService ProjectData { get; set; }
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Inject]
        public UserManager<IdentityUser> UserManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        private ProjectDisplayModel project = new ProjectDisplayModel();

        private IdentityUser User;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;

            User = await UserManager.GetUserAsync(authState.User);
        }

        private async Task CreateNewProject()
        {
            ProjectModel projectToSave = new ProjectModel
            {
                UserId = User.Id,
                Title = project.Title,
                Description = project.Description
            };

            var id = await ProjectData.CreateProject(projectToSave);

            NavMan.NavigateTo($"/projects/{id}");
        }

        private void OnCancelClick()
        {
            NavMan.NavigateTo("/projects");
        }
    }
}
