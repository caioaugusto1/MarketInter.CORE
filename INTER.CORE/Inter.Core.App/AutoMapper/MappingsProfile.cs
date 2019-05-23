using AutoMapper;
using Inter.Core.App.ViewModel;
using Inter.Core.Domain.Entities;

namespace Inter.Core.App.AutoMapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<EnvironmentViewModel, Inter.Core.Domain.Entities.Environment>().ReverseMap();
        }
    }
}
