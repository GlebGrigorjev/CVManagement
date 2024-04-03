using LatvijasPastsCore.Models.Enum;

namespace LatvijasPasts.UseCases.Models
{
    public class EducationViewModel
    {
        public string? School { get; set; }

        public Degrees? Degree { get; set; }

        public string? GraduationDate { get; set; }

        public string? City { get; set; }

        public string? Faculty { get; set; }
    }
}
