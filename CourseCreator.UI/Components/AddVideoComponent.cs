using AutoMapper;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Components
{
    public partial class AddVideoComponent
    {
        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int ProjectId { get; set; }

        [Parameter]
        public int SectionId { get; set; }

        [Parameter]
        public int OrderNo { get; set; }

        private VideoDisplayModel video = new VideoDisplayModel();

        public async Task CreateNewVideo()
        {
            var videoToSave = Mapper.Map<VideoModel>(video);
            videoToSave.SectionId = SectionId;
            videoToSave.OrderNo = OrderNo;

            await VideoData.CreateVideo(videoToSave);

            NavMan.NavigateTo($"/projects/{ProjectId}");
        }

        public void OnCancelClick()
        {
            NavMan.NavigateTo($"/projects/{ProjectId}");
        }
    }
}
