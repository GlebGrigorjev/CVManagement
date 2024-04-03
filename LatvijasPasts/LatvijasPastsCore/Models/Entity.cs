using System.Text.Json.Serialization;

namespace LatvijasPastsCore.Models
{
    public abstract class Entity
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
