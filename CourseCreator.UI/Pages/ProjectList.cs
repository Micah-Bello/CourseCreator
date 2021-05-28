using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
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
    public partial class ProjectList
    {
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Inject]
        public ProjectDataService ProjectData { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public UserManager<IdentityUser> UserManager { get; set; }

        private IdentityUser User;
        private List<ProjectModel> projects;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;

            User = await UserManager.GetUserAsync(authState.User);

            projects = await ProjectData.GetUserProjects(User.Id);
        }

        private void NewProject()
        {
            NavMan.NavigateTo("/projects/add-new");
        }
    }
}
