using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class AddMatchQuizComponent
    {
        [Inject]
        public MatchQuizDataService MatchQuizData { get; set; }
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Parameter]
        public int ProjectId { get; set; }
        [Parameter]
        public int SectionId { get; set; }
        [Parameter]
        public int OrderNo { get; set; }

        private bool showOptionForm = false;

        private MatchQuizDisplayModel quiz = new MatchQuizDisplayModel();

        private async Task CreateNewMatchQuiz()
        {
            MatchQuizModel quizToSave = new MatchQuizModel
            {
                Question = quiz.Question,
                SectionId = SectionId,
                OrderNo = OrderNo
            };

            foreach (var option in quiz.Options)
            {
                quizToSave.Options.Add(new MatchQuizOptionModel
                {
                    LeftOption = option.LeftOption,
                    RightOption = option.RightOption
                });
            }

            await MatchQuizData.CreateMatchQuiz(quizToSave);

            NavMan.NavigateTo($"/projects/{ProjectId}");
        }

        private void OpenOptionForm()
        {
            showOptionForm = true;
        }

        private void HandleAddOption(MatchQuizOptionDisplayModel quizOption)
        {
            quiz.Options.Add(quizOption);
            showOptionForm = false;
        }

        private void RemoveOption(MatchQuizOptionDisplayModel quizOption)
        {
            quiz.Options.Remove(quizOption);
        }

        public void OnCancelClick()
        {
            NavMan.NavigateTo($"/projects/{ProjectId}");
        }
    }
}
