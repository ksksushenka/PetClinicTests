using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicTests.Models.DataBase
{
    [Table("Owners")]
    public class OwnersTable
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("first_name")]
        public string? FirstName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }
        [Column("address")]
        public string? Address { get; set; }
        [Column("city")]
        public string? City { get; set; }
        [Column("telephone")]
        public string? Telephone { get; set; }
    }
}
