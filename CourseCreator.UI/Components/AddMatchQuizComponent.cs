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
    public partial class AddMatchQuizComponent
    {
        [Inject]
        public MatchQuizDataService MatchQuizData { get; set; }

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

        private MatchQuizDisplayModel quiz = new MatchQuizDisplayModel();

        private async Task CreateNewMatchQuiz()
        {
            var quizToSave = Mapper.Map<MatchQuizModel>(quiz);
            quizToSave.SectionId = SectionId;
            quizToSave.OrderNo = OrderNo;

            await MatchQuizData.CreateMatchQuiz(quizToSave);

            NavMan.NavigateTo($"/projects/{ProjectId}");
        }

        private void DisplayAddOptionForm()
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
