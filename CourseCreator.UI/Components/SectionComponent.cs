using AutoMapper;
using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using CourseCreator.UI.Data;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class SectionComponent
    {
        [Inject]
        public NavigationManager NavMan { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public SimpleQuizDataService SimpleQuizData { get; set; }

        [Inject]
        public MatchQuizDataService MatchQuizData { get; set; }

        [Inject]
        public VideoDataService VideoData { get; set; }

        [Inject]
        public ContentBlockDataService BlockData { get; set; }

        [Inject]
        public Content Content { get; set; }

        [Parameter]
        public SectionModel Section { get; set; }

        [Parameter]
        public int ProjectId { get; set; }

        private bool isExpanded = false;

        private List<CourseContentBase> blocks;

        private List<IContentDisplayable> ActiveBlocks => Content.SectionContent.Where(b => b.OrderNo != 0).ToList();

        protected override async Task OnInitializedAsync()
        {
            var simpleQuizzes = await SimpleQuizData.GetSectionQuizzes(Section.Id);

            var matchQuizzes = await MatchQuizData.GetSectionQuizzes(Section.Id);

            var videos = await VideoData.GetSectionVideos(Section.Id);

            Content.SectionContent.Clear();

            blocks = new List<CourseContentBase>();

            if (simpleQuizzes is not null)
            {
                foreach (var quiz in simpleQuizzes)
                {
                    quiz.Options = await SimpleQuizData.GetQuizOptions(quiz.Id);
                    var quizBlock = Mapper.Map<SimpleQuizDisplayModel>(quiz);
                    Content.SectionContent.Add(quizBlock);
                }

                blocks.AddRange(simpleQuizzes);
            }

            if (matchQuizzes is not null)
            {
                foreach (var quiz in matchQuizzes)
                {
                    quiz.Options = await MatchQuizData.GetQuizOptions(quiz.Id);
                    var quizBlock = Mapper.Map<MatchQuizDisplayModel>(quiz);
                    Content.SectionContent.Add(quizBlock);
                }

                blocks.AddRange(matchQuizzes);
            }

            if (videos is not null)
            {
                foreach (var video in videos)
                {
                    var videoBlock = Mapper.Map<VideoDisplayModel>(video);
                    Content.SectionContent.Add(videoBlock);
                }
                blocks.AddRange(videos);
            }
        }

        private void AddBlock()
        {
            NavMan.NavigateTo($"/projects/{ProjectId}/{Section.Id}/{ActiveBlocks.Count + 1}/add-new-block");
        }

        private async Task DeleteBlock(IContentDisplayable block)
        {
            //var num = block.OrderNo;

            //block.OrderNo = 0;

            //await BlockData.UpdateOrderNo(new List<CourseContentBase>() { block });

            //await UpdateBlocksBelowDeleted(num);
        }

        private async Task UpdateBlocksBelowDeleted(int deletedBlockOrderNo)
        {
            var blocksToUpdate = blocks.Where(x => x.OrderNo > deletedBlockOrderNo).ToList();

            blocksToUpdate.ForEach(x => x.OrderNo--);

            await BlockData.UpdateOrderNo(blocksToUpdate);
        }

        private void PreviewSection()
        {
            NavMan.NavigateTo($"/projects/view/0/");
        }

        private async Task MoveUp(IContentDisplayable block)
        {
            var blockOnTop = ActiveBlocks.Where(x => x.OrderNo == block.OrderNo - 1).FirstOrDefault();

            if (blockOnTop is not null)
            {
                blockOnTop.OrderNo++;
                block.OrderNo--;

                //var blocksToUpdate = new List<CourseContentBase>()
                //{
                //    Mapper.Map(blockOnTop);
                //    block
                //};

                //await BlockData.UpdateOrderNo(blocksToUpdate);
            }
        }

        private async Task MoveDown(IContentDisplayable block)
        {
            var blockBelow = ActiveBlocks.Where(x => x.OrderNo == block.OrderNo + 1).FirstOrDefault();

            if (blockBelow is not null)
            {
                blockBelow.OrderNo--;
                block.OrderNo++;

                //var blocksToUpdate = new List<CourseContentBase>()
                //{
                //    blockBelow,
                //    block
                //};

                //await BlockData.UpdateOrderNo(blocksToUpdate);
            }
        }

        private void PreviewBlock(IContentDisplayable block)
        {
            NavMan.NavigateTo($"/projects/view/{block.OrderNo}/");
        }

        public void ExpandCollapse()
        {
            isExpanded = !isExpanded;
        }
    }
}
