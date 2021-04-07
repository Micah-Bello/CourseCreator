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
    public partial class AddSimpleQuizComponent
    {
        [Inject]
        public SimpleQuizDataService SimpleQuizData { get; set; }
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Parameter]
        public int ProjectId { get; set; }
        [Parameter]
        public int SectionId { get; set; }
        [Parameter]
        public int OrderNo { get; set; }

        private bool showOptionForm = false;

        private SimpleQuizDisplayModel quiz = new SimpleQuizDisplayModel();


        private async Task CreateNewSimpleQuiz()
        {
            SimpleQuizModel quizToSave = new SimpleQuizModel
            {
                Question = quiz.Question,
                IsOpinionQuestion = quiz.IsOpinionQuestion,
                SectionId = SectionId,
                OrderNo = OrderNo
            };

            foreach (var option in quiz.Options)
            {
                quizToSave.Options.Add(new SimpleQuizOptionModel
                {
                    Text = option.Text,
                    IsAnswer = option.IsAnswer
                });
            }

            await SimpleQuizData.CreateSimpleQuiz(quizToSave);

            NavMan.NavigateTo($"/projects/{ProjectId}");
        }

        private void OpenOptionForm()
        {
            showOptionForm = true;
        }

        private void SetCorrectAnswer(SimpleQuizOptionDisplayModel quizOption)
        {
            foreach (var option in quiz.Options)
            {
                if (option.IsAnswer)
                {
                    option.IsAnswer = false;
                }
            }

            quizOption.IsAnswer = true;
        }

        private void HandleAddOption(SimpleQuizOptionDisplayModel quizOption)
        {
            if (quizOption.IsAnswer)
            {
                SetCorrectAnswer(quizOption);
            }

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
