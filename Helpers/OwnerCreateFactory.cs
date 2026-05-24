using PetClinicTests.Models.Petclinic;

namespace PetClinicTests.Helpers
{
    public static class OwnerCreateFactory
    {
        public static Owner GetNewOwner()
        {
            return new Owner()
            {
                FirstName = "TestOwnerFirstName",
                LastName = "TestOwnerLastName",
                Address = $"{DateTime.UtcNow.ToString()}",
                City = "Gomel",
                Telephone = "1234567890",
            };
        }

        public static Owner GetUpdatedOwner()
        {
            return new Owner()
            {
                FirstName = "TestOwnerFirstNameUpd",
                LastName = "TestOwnerLastNameUpd",
                Address = $"{DateTime.UtcNow.ToString()}",
                City = "GomelUpd",
                Telephone = "0987654321",
            };
        }
    }
}
