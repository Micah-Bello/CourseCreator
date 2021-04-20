using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
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

        private bool isExpanded = false;

        private List<IContentBlock> blocks;

        private List<IContentBlock> activeBlocks => blocks.Where(b => b.OrderNo != 0).ToList();

        protected override async Task OnInitializedAsync()
        {
            var simpleQuizzes = await SimpleQuizData.GetSectionQuizzes(Section.Id);

            var matchQuizzes = await MatchQuizData.GetSectionQuizzes(Section.Id);

            var videos = await VideoData.GetSectionVideos(Section.Id);

            blocks = new List<IContentBlock>();

            if (simpleQuizzes is not null)
            {
                foreach (var quiz in simpleQuizzes)
                {
                    quiz.DisplayTitle = quiz.Question;
                }

                blocks.AddRange(simpleQuizzes);
            }

            if (matchQuizzes is not null)
            {
                foreach (var quiz in matchQuizzes)
                {
                    quiz.DisplayTitle = quiz.Question;
                }

                blocks.AddRange(matchQuizzes);
            }

            if (videos is not null)
            {
                foreach (var video in videos)
                {
                    video.DisplayTitle = video.Title;
                }

                blocks.AddRange(videos);
            }
        }

        private void AddBlock()
        {
            NavMan.NavigateTo($"/projects/{ProjectId}/{Section.Id}/{blocks.Where(b => b.OrderNo != 0).ToList().Count + 1}/add-new-block");
        }

        private async Task DeleteBlock(IContentBlock block)
        {
            var num = block.OrderNo;

            block.OrderNo = 0;

            await BlockData.UpdateOrderNo(new List<IContentBlock>() { block });

            await UpdateBlocksBelowDeleted(num);
        }

        private async Task UpdateBlocksBelowDeleted(int deletedBlockOrderNo)
        {
            var blocksToUpdate = blocks.Where(x => x.OrderNo > deletedBlockOrderNo).ToList();

            blocksToUpdate.ForEach(x => x.OrderNo--);

            await BlockData.UpdateOrderNo(blocksToUpdate);
        }

        private void PreviewSection()
        {

        }

        private async Task MoveUp(IContentBlock block)
        {
            var blockOnTop = activeBlocks.Where(x => x.OrderNo == block.OrderNo - 1).FirstOrDefault();

            if (blockOnTop is not null)
            {
                blockOnTop.OrderNo++;
                block.OrderNo--;

                var blocksToUpdate = new List<IContentBlock>()
                {
                    blockOnTop,
                    block
                };

                await BlockData.UpdateOrderNo(blocksToUpdate);
            }
        }

        private async Task MoveDown(IContentBlock block)
        {
            var blockBelow = activeBlocks.Where(x => x.OrderNo == block.OrderNo + 1).FirstOrDefault();

            if (blockBelow is not null)
            {
                blockBelow.OrderNo--;
                block.OrderNo++;

                var blocksToUpdate = new List<IContentBlock>()
                {
                    blockBelow,
                    block
                };

                await BlockData.UpdateOrderNo(blocksToUpdate);
            }
        }

        private void PreviewBlock(IContentBlock block)
        {
            NavMan.NavigateTo($"/projects/{block.Id}/{(int)block.Type}/preview");
        }

        public void ExpandCollapse()
        {
            isExpanded = !isExpanded;
        }
    }
}
