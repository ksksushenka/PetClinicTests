using System.Text.Json.Serialization;

namespace PetClinicTests.Models.Petclinic
{
    public record Visit
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("petId")]
        public int PetId { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("date")]
        public string? Date { get; set; }
    }
}
