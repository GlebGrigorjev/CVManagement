using LatvijasPastsCore.Models.Enum;
using System.Text.Json.Serialization;

namespace LatvijasPastsCore.Models
{
    public class Education : Entity
    {
        public string? School { get; set; }

        public Degrees? Degree { get; set; }

        public string? GraduationDate { get; set; }

        public string? City { get; set; }

        public string? Faculty { get; set; }

        [JsonIgnore]
        public int CVDataId { get; set; }
    }
}
