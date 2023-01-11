using System.Text.Json.Serialization;

namespace API.GClaims.Domain.ValueObjects.Client
{
    public class ValueObjectBase
    {
        [JsonIgnore]
        public bool Success { get; set; }
        [JsonIgnore]
        public string Message { get; set; }
    }
}
