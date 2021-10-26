using AutoMapper;
using CourseCreator.Library;
using CourseCreator.Library.Data;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Pages
{
    public partial class DisplayBlock
    {
        [Parameter]
        public int OrderNo { get; set; }
        
        [Inject]
        public Content Content { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private bool isPreviewOne;
        private bool ready;

        private IContentDisplayable blockToDisplay => Content.SectionContent.Where(x => x.OrderNo == OrderNo).FirstOrDefault();

        

        protected override void OnInitialized()
        {
            

            if (OrderNo != 0)
            {
                isPreviewOne = true;
            }
            else
            {
                OrderNo = 1;
            }

            ready = true;
        }

        private void AdvanceToNextBlock() => OrderNo++;

        private void ReturnToPreviousBlock() => OrderNo--;
    }
}
