using PetClinicTests.Models.Petclinic;

namespace PetClinicTests.Helpers
{
    public static class OwnerCreateFactory
    {
        public static Owner GetNewOwner()
        {
            return new Owner()
            {
                FirstName = "TestOwner",
                LastName = "Belarus",
                Address = $"{DateTime.UtcNow.ToString()}",
                City = "Gomel",
                Telephone = "1234567890",
            };
        }
    }
}
