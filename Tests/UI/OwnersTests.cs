using FluentAssertions;
using FluentAssertions.Execution;
using PetClinicTests.Helpers;
using PetClinicTests.Models.Petclinic;
using PetClinicTests.Pages;
using PetClinicTests.Services.API;
using PetClinicTests.Services.DataBases;

namespace PetClinicTests.Tests.UI
{
    public class OwnersTests : BaseTest
    {
        private OwnersAddPage OwnersAddPage;
        private OwnersDBService _ownersDBService;
        private OwnersService _ownersService;

        private Owner? newOwner;

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
            newOwner = OwnerCreateFactory.GetNewOwner();

            //Create a new owner
            await OwnersAddPage.CreateNewOwner(newOwner);

            newOwner.Id = _ownersDBService.GetLastAddedOwner().Id;

            var actualAddedOwner = await _ownersService.GetOwnerAsync(newOwner.Id);

            //Assertion
            using (new AssertionScope())
            {
                actualAddedOwner.Should().NotBeNull();
                actualAddedOwner.FirstName.Should().Be(newOwner.FirstName);
                actualAddedOwner.LastName.Should().Be(newOwner.LastName);
                actualAddedOwner.Address.Should().Be(newOwner.Address);
                actualAddedOwner.City.Should().Be(newOwner.City);
                actualAddedOwner.Telephone.Should().Be(newOwner.Telephone);
            }
        }

        [TearDown]
        public async Task DeleteCreatedOwnerAfterTest()
        {
            if (newOwner != null)
            {
                await _ownersService.DeleteOwnerAsync(newOwner.Id);
            }
        }
    }
}
