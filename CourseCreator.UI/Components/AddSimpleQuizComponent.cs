using AutoMapper;
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

        [Inject]
        public IMapper Mapper { get; set; }

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
            var quizToSave = Mapper.Map<SimpleQuizModel>(quiz);
            quizToSave.SectionId = SectionId;
            quizToSave.OrderNo = OrderNo;

            await SimpleQuizData.CreateSimpleQuiz(quizToSave);

            NavMan.NavigateTo($"/projects/{ProjectId}");
        }

        private void DisplayAddOptionForm()
        {
            showOptionForm = true;
        }

        private void SetOptionAsCorrectAnswer(SimpleQuizOptionDisplayModel quizOption)
        {
            quiz.Options.ForEach(o => o.IsAnswer = false);

            quizOption.IsAnswer = true;
        }

        private void HandleAddOption(SimpleQuizOptionDisplayModel quizOption)
        {
            if (quizOption.IsAnswer)
            {
                SetOptionAsCorrectAnswer(quizOption);
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
