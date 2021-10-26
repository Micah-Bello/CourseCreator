using AutoMapper;
using CourseCreator.Library.Models;
using CourseCreator.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SimpleQuizModel, SimpleQuizDisplayModel>().ReverseMap();
            CreateMap<SimpleQuizOptionModel, SimpleQuizOptionDisplayModel>().ReverseMap();
            CreateMap<MatchQuizModel, MatchQuizDisplayModel>().ReverseMap();
            CreateMap<MatchQuizOptionModel, MatchQuizOptionDisplayModel>().ReverseMap();
            CreateMap<VideoModel, VideoDisplayModel>();
        }
    }
}
