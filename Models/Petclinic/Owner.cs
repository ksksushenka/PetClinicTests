using System.Text.Json.Serialization;

namespace PetClinicTests.Models.Petclinic
{
    public record Owner
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("telephone")]
        public string? Telephone { get; set; }
        [JsonPropertyName("pets")]
        public List<Pet>? Pets { get; set; }
    }
}
