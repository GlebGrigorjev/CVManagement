using AutoMapper;
using FluentAssertions;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.Models;
using LatvijasPasts.UseCases.Validations;
using LatvijasPastsCore.Models.Enum;
using Moq;

namespace LatvijasPasts.Tests.UseCasesTests.Validator
{
    [TestClass]
    public class CvCreateRequestValidatorTests
    {
        private IMapper _mapperMock;
        private ICvDataService _cvDataServiceMock;
        private CvViewModelValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _mapperMock = Mock.Of<IMapper>();
            _cvDataServiceMock = Mock.Of<ICvDataService>();

            _validator = new CvViewModelValidator(_mapperMock, _cvDataServiceMock);
        }

        [TestMethod]
        public void Validate_With_Valid_CvViewModel_Should_Not_Have_Errors()
        {
            var validCvViewModel = new CvViewModel
            {
                AvatarUrl = "avatar-url",
                ColourUrl = "colour-url",
                DateOfBirth = "2022-02-22",
                EMail = "test@example.com",
                Name = "John",
                PhoneNumber = "123456789",
                Surname = "Doe",
                CurrentAddress = new LivingAddressViewModel
                {
                    Country = "Country",
                    City = "City",
                    PostalIndex = "Postal Index",
                    Street = "Street"
                },
                Educations = new List<EducationViewModel>
                {
                    new EducationViewModel
                    {
                        School = "School",
                        Degree = Degrees.MastersDegree,
                        GraduationDate = "2021-06-30",
                        City = "City",
                        Faculty = "Faculty"
                    }
                },
                WorkExperiences = new List<PreviousWorkExperienceViewModel>
                {
                    new PreviousWorkExperienceViewModel
                    {
                        Employer = "Employer",
                        JobTitle = "Job Title",
                        StartDate = "2020-01-01",
                        EndDate = "2021-01-01",
                        City = "City"
                    }
                },
                Languages = new List<LanguageViewModel>
                {
                    new LanguageViewModel
                    {
                        Language = "Language",
                        Speaking = Categories.A2,
                        Listening = Categories.A1,
                        Writing = Categories.B2
                    }
                },
                Skills = new List<AdditionalSkillsViewModel>
                {
                new AdditionalSkillsViewModel
                    {
                        Skill = "Skill"
                    }
                }
            };

            var validationResult = _validator.Validate(validCvViewModel);

            validationResult.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Validate_With_Invalid_CvViewModel_Should_Have_Errors()
        {
            var invalidCvViewModel = new CvViewModel
            {
            };

            var validationResult = _validator.Validate(invalidCvViewModel);

            validationResult.IsValid.Should().BeFalse();
        }
    }
}
