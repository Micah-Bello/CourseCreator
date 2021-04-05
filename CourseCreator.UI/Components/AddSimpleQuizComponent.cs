using CourseCreator.Library.Data;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class AddSimpleQuizComponent
    {
        [Inject]
        public SimpleQuizDataService SimpleQuizData { get; set; }
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Parameter]
        public int ProjectId { get; set; }
        private bool showOptionForm = false;

        private SimpleQuizDisplayModel quiz = new SimpleQuizDisplayModel();

        protected override async Task OnInitializedAsync()
        {
            
        }

        private void CreateNewSimpleQuiz()
        {

        }

        private void OpenOptionForm()
        {
            showOptionForm = true;
        }

        private void HandleAddOption(SimpleQuizOptionDisplayModel quizOption)
        {
            quiz.Options.Add(quizOption);
            showOptionForm = false;
        }

        private void RemoveOption(SimpleQuizOptionDisplayModel quizOption)
        {
            quiz.Options.Remove(quizOption);
        }

        public void OnCancelClick()
        {
            NavMan.NavigateTo($"/projects/{ProjectId}");
        }
    }
}
