using System.Text.Json.Serialization;

namespace PetClinicTests.Models.Petclinic
{
    public record Owner
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }
        [JsonPropertyName("address")]
        public required string Address { get; set; }
        [JsonPropertyName("city")]
        public required string City { get; set; }
        [JsonPropertyName("telephone")]
        public required string Telephone { get; set; }
        [JsonPropertyName("pets")]
        public List<Pet>? Pets { get; set; }
    }
}
