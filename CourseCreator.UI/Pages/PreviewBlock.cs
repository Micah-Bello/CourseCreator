using CourseCreator.Library;
using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    public partial class PreviewBlock
    {
        [Parameter]
        public int ProjectId { get; set; }
        [Parameter]
        public int SectionId { get; set; }
        [Parameter]
        public int BlockId { get; set; }
        [Parameter]
        public Enums.BlockTypes BlockType { get; set; }
        [Inject]
        public SimpleQuizDataService SimpleQuizData { get; set; }
        [Inject]
        public MatchQuizDataService MatchQuizData { get; set; }

        private SimpleQuizModel quizBlock;
        private MatchQuizModel matchQuizBlock;

        private bool ready;

        protected override async Task OnInitializedAsync()
        {
            switch (BlockType)
            {
                case Enums.BlockTypes.SimpleQuiz:
                    quizBlock = await SimpleQuizData.GetQuiz(BlockId);
                    break;
                case Enums.BlockTypes.MatchQuiz:
                    matchQuizBlock = await MatchQuizData.GetQuiz(BlockId);
                    break;
                default:
                    break;
            }

            ready = true;
        }
    }
}
