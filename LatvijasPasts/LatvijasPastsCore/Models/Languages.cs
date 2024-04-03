using LatvijasPastsCore.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LatvijasPastsCore.Models
{
    public class Languages : Entity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string? Language { get; set; }

        public Categories? Speaking { get; set; }

        public Categories? Listening { get; set; }

        public Categories? Writing { get; set; }

        [JsonIgnore]
        public int CVDataId { get; set; }
    }
}
