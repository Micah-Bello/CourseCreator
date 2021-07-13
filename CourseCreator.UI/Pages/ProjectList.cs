using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    public partial class ProjectList : IDisposable
    {
        [Inject] public NavigationManager NavMan { get; set; }
        [Inject] public ProjectDataService ProjectData { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject] public UserManager<IdentityUser> UserManager { get; set; }

        [Inject] public IJSRuntime JSRuntime { get; set; }

        private IdentityUser User;
        private List<ProjectModel> projects;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;

            User = await UserManager.GetUserAsync(authState.User);

            projects = await ProjectData.GetUserProjects(User.Id);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeAsync<object>("TestDataTablesAdd", "#projectsList");
        }

        private void NewProject()
        {
            NavMan.NavigateTo("/projects/add-new");
        }

        public void EditProject(int projectId)
        {
            NavMan.NavigateTo($"/projects/{projectId}");
        }

        public void PreviewProject()
        {

        }

        public void Dispose()
        {
            JSRuntime.InvokeAsync<object>("TestDataTablesRemove", "#projectsList");
        }
    }
}
