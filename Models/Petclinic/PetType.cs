using System.Text.Json.Serialization;

namespace PetClinicTests.Models.Petclinic
{
    public record PetType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
