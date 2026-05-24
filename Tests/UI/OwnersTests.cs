using FluentAssertions;
using FluentAssertions.Execution;
using PetClinicTests.Helpers;
using PetClinicTests.Models.Petclinic;
using PetClinicTests.Pages;
using PetClinicTests.Services.API;
using PetClinicTests.Services.DataBases;

namespace PetClinicTests.Tests.UI
{
    [AllureNUnit]
    public class OwnersTests : BaseTest
    {
        private OwnersAddPage OwnersAddPage;
        private OwnerInformationPage OwnerInformationPage;
        private OwnersEditPage OwnersEditPage;
        private OwnersPage OwnersPage;
        private OwnersDBService _ownersDBService;
        private OwnersService _ownersService;

        private Owner? newOwner;
        private Owner? updatedOwner;

        [SetUp]
        public async Task InitializationOwners()
        {
            OwnersAddPage = new OwnersAddPage(Page);
            OwnerInformationPage = new OwnerInformationPage(Page);
            OwnersEditPage = new OwnersEditPage(Page);
            OwnersPage = new OwnersPage(Page);
            _ownersDBService = new OwnersDBService(_petClinicDBConnector);
            _ownersService = new OwnersService(Playwright);
        }

        [Test]
        public async Task CreateNewOwner()
        {
            newOwner = OwnerCreateFactory.GetNewOwner();

            //Create a new owner
            newOwner = await OwnersAddPage.CreateNewOwner(newOwner);

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

        [Test]
        public async Task UpdateOwner()
        {         
            newOwner = OwnerCreateFactory.GetNewOwner();

            //Create a new owner
            newOwner = await OwnersAddPage.CreateNewOwner(newOwner);

            var ownerFullname = $"{newOwner.FirstName} {newOwner.LastName}";

            //Find created owner
            await OwnersPage.FindOwnerbyLastName(newOwner.LastName);
            await OwnersPage.ClickOnOwner(ownerFullname);
            await OwnerInformationPage.ClickEditOwnerButton();

            //Update Owner
            updatedOwner = OwnerCreateFactory.GetUpdatedOwner();
            await OwnersEditPage.EditOwner(updatedOwner);

            var actualUpdatedOwner = await _ownersService.GetOwnerAsync(newOwner.Id);

            //Assertion
            using (new AssertionScope())
            {
                actualUpdatedOwner.Should().NotBeNull();
                actualUpdatedOwner.FirstName.Should().Be(updatedOwner.FirstName);
                actualUpdatedOwner.LastName.Should().Be(updatedOwner.LastName);
                actualUpdatedOwner.Address.Should().Be(updatedOwner.Address);
                actualUpdatedOwner.City.Should().Be(updatedOwner.City);
                actualUpdatedOwner.Telephone.Should().Be(updatedOwner.Telephone);
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
