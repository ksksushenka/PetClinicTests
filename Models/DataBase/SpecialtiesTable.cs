using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicTests.Models.DataBase
{
    [Table("specialties")]
    public class SpecialtiesTable
    {
        [Column("id")]
        [Key]
        public int CampaignId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
    }
}
