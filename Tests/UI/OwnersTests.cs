using FluentAssertions.Execution;
using PetClinicTests.Pages;

namespace PetClinicTests.Tests.UI
{
    public class OwnersTests : BaseTest
    {
        private OwnersAddPage OwnersAddPage;

        //private string? firstName;
        //private string? lastName;
        //private string? address;
        //private string? city;
        //private string? phone;

        [SetUp]
        public async Task InitializationOwners()
        {
            OwnersAddPage = new OwnersAddPage(Page);
        }

        [Test]
        public async Task CreateNewOwner()
        {
            var firstName = "Kseniya";
            var lastName = "Test";
            var address = "Test address 123";
            var city = "Minsk";
            var phone = "1234567890";

            //Open Owners Add Page
            await OwnersAddPage.NavigateToOwnersAddPage();
            await OwnersAddPage.CreateOwner(firstName, lastName, address, city, phone);

            //Assertion
            using (new AssertionScope())
            {
            }
        }
    }
}
