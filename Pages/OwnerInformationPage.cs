using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using PetClinicTests.Models.Petclinic;
using Serilog;

namespace PetClinicTests.Pages
{
    public class OwnerInformationPage: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public OwnerInformationPage(IPage page) : base(page) { }
        protected override string Endpoint => "owners/";

        private ILocator _ownerInformationText => _page.GetByRole(AriaRole.Heading, new() { Name = "Owner Information" });
        private ILocator _petsAndVisitsText => _page.GetByRole(AriaRole.Heading, new() { Name = "Pets and Visits" });
        private ILocator _editOwnerButton => _page.GetByRole(AriaRole.Button, new () {Name = "Edit Owner" });
        private ILocator _addNewPetButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add New Pet" });
        private ILocator _editPetButton => _page.GetByRole(AriaRole.Button, new() { Name = "Edit Pet" });
        private ILocator _deletePetButton => _page.GetByRole(AriaRole.Button, new() { Name = "Delete Pet" });
        private ILocator _addVisitButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Visit" });
        private ILocator _editVisitButton => _page.GetByRole(AriaRole.Button, new() { Name = "Edit Visit" });
        private ILocator _deleteVisitButton => _page.GetByRole(AriaRole.Button, new() { Name = "Delete Visit" });
        private ILocator _ownerFullNameText => _page.Locator(".ownerFullName");
            
        public async Task<OwnerInformationPage> NavigateToOwnerInformationPage(int id)
        {
            await _page.GotoAsync(FullUrl + id);
            _logger.Information($"Navigated to {FullUrl + id}");

            await _ownerInformationText.WaitForAsync();

            return this;
        }

        // Methods
        public async Task ClickEditOwnerButton()
        {
            await _editOwnerButton.ClickAsync();

            _logger.Information("Owner Edit Page is open.");
        }

        public async Task ClickAddNewPetButton()
        {
            await _addNewPetButton.ClickAsync();

            _logger.Information("Add Pet Page is open.");
        }

        public async Task ClickEditPetButton()
        {
            await _editPetButton.ClickAsync();

            _logger.Information("Edit Pet Page is open.");
        }

        public async Task ClickDeletePetButton()
        {
            await _deletePetButton.ClickAsync();

            _logger.Information("Pet is deleted.");
        }

        public async Task ClickAddVisitButton()
        {
            await _addVisitButton.ClickAsync();

            _logger.Information("Add Visit Page is open.");
        }

        public async Task ClickEditVisitButton()
        {
            await _editVisitButton.ClickAsync();

            _logger.Information("Edit Visit Page is open.");
        }

        public async Task ClickDeleteVisitButton()
        {
            await _deleteVisitButton.ClickAsync();

            _logger.Information("Visit is deleted.");
        }

        public async Task<string?> GetOwnerFullName()
        {
            await _ownerFullNameText.WaitForAsync();
            return await _ownerFullNameText.TextContentAsync();
        }

        public async Task IsOpen()
        {
            _page.Url.Should().Be(FullUrl);

            var text1 = await _ownerInformationText.TextContentAsync();
            var text2 = await _petsAndVisitsText.TextContentAsync();

            using (new AssertionScope())
            {
                text1.Should().Be("Owner Information");
                text2.Should().Be("Pets and Visits");
            }
        }
    }
}