using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LatvijasPastsCore.Models
{
    public class LivingAddress : Entity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string? Country { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? City { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PostalIndex { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Street { get; set; }

        [JsonIgnore]
        public int CVDataId { get; set; }
    }
}
