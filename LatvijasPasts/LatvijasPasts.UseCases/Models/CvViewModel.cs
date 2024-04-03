namespace LatvijasPasts.UseCases.Models
{
    public class CvViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EMail { get; set; }
        public string? DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }
        public string? ColourUrl { get; set; }
        public LivingAddressViewModel? CurrentAddress { get; set; }
        public List<EducationViewModel>? Educations { get; set; }
        public List<PreviousWorkExperienceViewModel>? WorkExperiences { get; set; }
        public List<LanguageViewModel>? Languages { get; set; }
        public List<AdditionalSkillsViewModel>? Skills { get; set; }
    }
}
