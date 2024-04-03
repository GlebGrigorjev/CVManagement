using System.ComponentModel.DataAnnotations;

namespace LatvijasPastsCore.Models
{
    public class CVData : Entity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? EMail { get; set; }

        [Required]
        public string? DateOfBirth { get; set; }

        [Required]
        public string? AvatarUrl { get; set; }

        [Required]
        public string? ColourUrl { get; set; }

        public LivingAddress? CurrentAddress { get; set; }

        public List<Education>? Educations { get; set; }

        public List<PreviousWorkExperiences>? WorkExperiences { get; set; }

        public List<Languages>? Languages { get; set; }

        public List<AdditionalSkills>? Skills { get; set; }
    }
}
