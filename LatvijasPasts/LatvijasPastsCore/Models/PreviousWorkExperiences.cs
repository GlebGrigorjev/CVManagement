using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LatvijasPastsCore.Models
{
    public class PreviousWorkExperiences : Entity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string? Employer { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? JobTitle { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? StartDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? EndDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? City { get; set; }

        [JsonIgnore]
        public int CVDataId { get; set; }
    }
}
