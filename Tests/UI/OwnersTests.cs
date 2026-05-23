using FluentAssertions;
using FluentAssertions.Execution;
using PetClinicTests.Pages;
using PetClinicTests.Services.API;
using PetClinicTests.Services.DataBases;
using PetClinicTests.Steps;

namespace PetClinicTests.Tests.UI
{
    public class OwnersTests : BaseTest
    {
        private OwnersAddPage OwnersAddPage;
        private OwnersDBService _ownersDBService;
        private OwnersService _ownersService;

        private int addedOwnerId;

        [SetUp]
        public async Task InitializationOwners()
        {
            OwnersAddPage = new OwnersAddPage(Page);
            _ownersDBService = new OwnersDBService(_petClinicDBConnector);
            _ownersService = new OwnersService(Playwright);
        }

        [Test]
        public async Task CreateNewOwner()
        {
            var firstName = "Kseniya";
            var lastName = "Test";
            var address = "Test address 123";
            var city = "Minsk";
            var phone = "1234567890";

            //Create a new owner
            await OwnersAddPage.CreateNewOwner(firstName, lastName, address, city, phone);

            addedOwnerId = _ownersDBService.GetLastAddedOwner().Id;

            var actualAddedOwner = await _ownersService.GetOwnerAsync(addedOwnerId);

            //Assertion
            using (new AssertionScope())
            {
                actualAddedOwner.Should().NotBeNull();
                actualAddedOwner.FirstName.Should().Be(firstName);
                actualAddedOwner.LastName.Should().Be(lastName);
                actualAddedOwner.Address.Should().Be(address);
                actualAddedOwner.City.Should().Be(city);
                actualAddedOwner.Telephone.Should().Be(phone);
            }
        }

        [TearDown]
        public async Task DeleteCreatedOwnerAfterTest()
        {
            await _ownersService.DeleteOwnerAsync(addedOwnerId);
        }
    }
}
