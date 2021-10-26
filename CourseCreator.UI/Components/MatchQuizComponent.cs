using CourseCreator.Library;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class MatchQuizComponent
    {
        [Parameter]
        public MatchQuizDisplayModel Quiz { get; set; }

        private List<MatchQuizOptionDisplayModel> leftOptions;
        private List<MatchQuizOptionDisplayModel> rightOptions;

        private MatchQuizOptionDisplayModel leftOption;
        private MatchQuizOptionDisplayModel rightOption;

        protected override void OnParametersSet()
        {
            leftOptions = GetShuffledList();
            rightOptions = GetShuffledList();
        }

        private List<MatchQuizOptionDisplayModel> GetShuffledList(){
            return Quiz.Options.Shuffle().Select(x =>
                new MatchQuizOptionDisplayModel
                {
                    Id = x.Id,
                    LeftOption = x.LeftOption,
                    RightOption = x.RightOption,
                    IsMatched = x.IsMatched
                }).ToList();
        }

        public bool MatchFound => rightOption.Id == leftOption.Id;

        public void HandleLeftOptionClick(MatchQuizOptionDisplayModel option)
        {
            leftOption = option;

            if (rightOption is not null)
            {
                if (MatchFound)
                {
                    HandleMatch();
                }
                else
                {
                    rightOption = null;
                }
            }

        }

        public void HandleRightOptionClick(MatchQuizOptionDisplayModel option)
        {
            rightOption = option;

            if (leftOption is not null)
            {
                if (MatchFound)
                {
                    HandleMatch();
                }
                else
                {
                    leftOption = null;
                }
            }
        }

        private void HandleMatch()
        {
            leftOption.IsMatched = true;
            rightOption.IsMatched = true;
        }

    }
}
