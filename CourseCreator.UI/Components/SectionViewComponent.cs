﻿using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class SectionViewComponent
    {
        [Inject]
        public NavigationManager NavMan { get; set; }
        [Inject]
        public SimpleQuizDataService SimpleQuizData { get; set; }
        [Inject]
        public MatchQuizDataService MatchQuizData { get; set; }
        [Inject]
        public VideoDataService VideoData { get; set; }
        [Inject]
        public ContentBlockDataService BlockData { get; set; }

        [Parameter]
        public SectionModel Section { get; set; }
        [Parameter]
        public int ProjectId { get; set; }
        [Parameter]
        public int SectionNo { get; set; }

        private bool isExpanded = false;

        private List<CourseContentBase> blocks = new();

        private List<CourseContentBase> activeBlocks => blocks.Where(b => b.OrderNo != 0).ToList();

        protected override async Task OnInitializedAsync()
        {
            var simpleQuizzes = await SimpleQuizData.GetSectionQuizzes(Section.Id);

            var matchQuizzes = await MatchQuizData.GetSectionQuizzes(Section.Id);

            var videos = await VideoData.GetSectionVideos(Section.Id);

            blocks = new List<CourseContentBase>();

            if (simpleQuizzes is not null)
            {
                foreach (var quiz in simpleQuizzes)
                {
                    quiz.Options = await SimpleQuizData.GetQuizOptions(quiz.Id);
                }

                blocks.AddRange(simpleQuizzes);
            }

            if (matchQuizzes is not null)
            {
                foreach (var quiz in matchQuizzes)
                {
                    quiz.Options = await MatchQuizData.GetQuizOptions(quiz.Id);
                }

                blocks.AddRange(matchQuizzes);
            }

            if (videos is not null)
            {

                blocks.AddRange(videos);
            }
        }
    }
}
