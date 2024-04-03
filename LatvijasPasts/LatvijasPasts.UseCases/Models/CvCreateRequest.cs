using LatvijasPastsCore.Models;
using System.Text.Json.Serialization;

namespace LatvijasPasts.UseCases.Models
{
    public class CvCreateRequest
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EMail { get; set; }

        public string? DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }
        public string? ColourUrl { get; set; }

        public LivingAddress? CurrentAddress { get; set; }

        public List<Education?> Educations { get; set; }

        public List<PreviousWorkExperiences?> WorkExperiences { get; set; }

        public List<Languages?> Languages { get; set; }

        public List<AdditionalSkills?> Skills { get; set; }

        [JsonIgnore]
        public new int? Id { get; set; }
    }
}
