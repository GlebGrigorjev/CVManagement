using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LatvijasPastsCore.Models
{
    public class AdditionalSkills : Entity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string? Skill { get; set; }

        [JsonIgnore]
        public int CVDataId { get; set; }
    }
}
