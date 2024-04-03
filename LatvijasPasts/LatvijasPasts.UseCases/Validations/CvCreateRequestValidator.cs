using AutoMapper;
using FluentValidation;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;

namespace LatvijasPasts.UseCases.Validations
{
    public class CvViewModelValidator : AbstractValidator<CvViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICvDataService _cvDataService;

        public CvViewModelValidator(IMapper mapper,
            ICvDataService cvDataService)
        {
            _mapper = mapper;
            _cvDataService = cvDataService;

            RuleFor(cv => cv.Name).NotEmpty().Length(1, 50);
            RuleFor(cv => cv.Surname).NotEmpty().Length(1, 50);
            RuleFor(cv => cv.PhoneNumber).NotEmpty().Length(1, 50);
            RuleFor(cv => cv.EMail).NotEmpty().Length(1, 50).EmailAddress();
            RuleFor(cv => cv.DateOfBirth).NotEmpty().Length(1, 50);
            RuleFor(cv => cv.CurrentAddress).SetValidator(new LivingAddressViewModelValidator());

            RuleForEach(cv => cv.Educations).SetValidator(new EducationViewModelValidator());
            RuleForEach(cv => cv.WorkExperiences).SetValidator(new PreviousWorkExperienceViewModelValidator());
            RuleForEach(cv => cv.Languages).SetValidator(new LanguageViewModelValidator());
            RuleForEach(cv => cv.Skills).SetValidator(new AdditionalSkillsViewModelValidator());

            RuleFor(cv => cv)
                .Must(IsCvUnique).WithMessage("Duplicate CVs not Allowed");
        }


        public class LivingAddressViewModelValidator : AbstractValidator<LivingAddressViewModel>
        {
            public LivingAddressViewModelValidator()
            {
                RuleFor(address => address.Country).NotEmpty().Length(1, 50);
                RuleFor(address => address.City).NotEmpty().Length(1, 50);
                RuleFor(address => address.PostalIndex).NotEmpty().Length(1, 50);
                RuleFor(address => address.Street).NotEmpty().Length(1, 50);
            }
        }

        public class EducationViewModelValidator : AbstractValidator<EducationViewModel>
        {
            public EducationViewModelValidator()
            {
                RuleFor(edu => edu.School).NotEmpty().Length(1, 50);
                RuleFor(edu => edu.Degree).NotNull().IsInEnum();
                RuleFor(edu => edu.GraduationDate).NotEmpty().Length(1, 50);
                RuleFor(edu => edu.City).NotEmpty().Length(1, 50);
                RuleFor(edu => edu.Faculty).NotEmpty().Length(1, 50);
            }
        }

        public class PreviousWorkExperienceViewModelValidator : AbstractValidator<PreviousWorkExperienceViewModel>
        {
            public PreviousWorkExperienceViewModelValidator()
            {
                RuleFor(work => work.Employer).NotEmpty().Length(1, 50);
                RuleFor(work => work.JobTitle).NotEmpty().Length(1, 50);
                RuleFor(work => work.StartDate).NotEmpty().Length(1, 50).LessThan(work => work.EndDate);
                RuleFor(work => work.EndDate).NotEmpty().Length(1, 50).GreaterThan(work => work.StartDate);
                RuleFor(work => work.City).NotEmpty().Length(1, 50);
            }
        }

        public class LanguageViewModelValidator : AbstractValidator<LanguageViewModel>
        {
            public LanguageViewModelValidator()
            {
                RuleFor(lang => lang.Language).NotEmpty().Length(1, 50);
                RuleFor(lang => lang.Speaking).NotNull().IsInEnum();
                RuleFor(lang => lang.Listening).NotNull().IsInEnum();
                RuleFor(lang => lang.Writing).NotNull().IsInEnum();
            }
        }

        public class AdditionalSkillsViewModelValidator : AbstractValidator<AdditionalSkillsViewModel>
        {
            public AdditionalSkillsViewModelValidator()
            {
                RuleFor(skill => skill.Skill).NotEmpty().Length(1, 50);
            }
        }

        private bool IsCvUnique(CvViewModel newCv)
        {
            var map = _mapper.Map<CVData>(newCv);

            return !_cvDataService.CheckForDuplicates(map);
        }
    }
}
