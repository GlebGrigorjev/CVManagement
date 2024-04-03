using AutoMapper;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;

namespace LatvijasPasts.UseCases.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CvCreateRequest, CVData>()
                    .ForMember(destination => destination.Id,
                    options => options.Ignore());

            CreateMap<CVData, CvCreateRequest>();

            CreateMap<Education, EducationViewModel>();
            CreateMap<EducationViewModel, Education>();

            CreateMap<PreviousWorkExperiences, PreviousWorkExperienceViewModel>();
            CreateMap<PreviousWorkExperienceViewModel, PreviousWorkExperiences>();

            CreateMap<LivingAddress, LivingAddressViewModel>();
            CreateMap<LivingAddressViewModel, LivingAddress>();

            CreateMap<Languages, LanguageViewModel>();
            CreateMap<LanguageViewModel, Languages>();

            CreateMap<AdditionalSkills, AdditionalSkillsViewModel>();
            CreateMap<AdditionalSkillsViewModel, AdditionalSkills>();

            CreateMap<CVData, CvViewModel>();
            CreateMap<CvViewModel, CVData>();
        }
    }
}
