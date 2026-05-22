using System.Text.Json.Serialization;

namespace PetClinicTests.Models.Petclinic
{
    public record Pet
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("birthDate")]
        public string? BirthDate { get; set; }
        [JsonPropertyName("ownerId")]
        public int? OwnerId { get; set; }
        [JsonPropertyName("type")]
        public PetType? Type { get; set; }
        [JsonPropertyName("visits")]
        public List<Visit>? Visits { get; set; }
    }
}
