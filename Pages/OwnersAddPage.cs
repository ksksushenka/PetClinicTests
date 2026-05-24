using FluentAssertions;
using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using PetClinicTests.Models.Petclinic;
using Serilog;
using System.Text.Json;

namespace PetClinicTests.Pages
{
    public class OwnersAddPage: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public OwnersAddPage(IPage page) : base(page) { }
        protected override string Endpoint => "owners/add";

        private ILocator _newOwnerText => _page.GetByRole(AriaRole.Heading, new() { Name = "New Owner" });
        private ILocator _firstNameField => _page.GetByRole(AriaRole.Textbox, new () {Name = "First Name"});
        private ILocator _lastNameField => _page.GetByRole(AriaRole.Textbox, new() {Name = "Last Name"});
        private ILocator _addressField => _page.GetByRole(AriaRole.Textbox, new() {Name = "Address" });
        private ILocator _cityField => _page.GetByRole(AriaRole.Textbox, new() { Name = "City" });
        private ILocator _telephoneField => _page.GetByRole(AriaRole.Textbox, new() { Name = "Telephone" });
        private ILocator _addOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Owner" });

        public async Task<OwnersAddPage> NavigateToOwnersAddPage()
        {
            await _page.GotoAsync(FullUrl);
            _logger.Information($"Navigated to {FullUrl}");

            await _newOwnerText.WaitForAsync();

            return this;
        }

        // Methods
        public async Task<Owner> CreateNewOwner(Owner owner)
        {
            await NavigateToOwnersAddPage();
            await _firstNameField.FillAsync(owner.FirstName);
            await _lastNameField.FillAsync(owner.LastName);
            await _addressField.FillAsync(owner.Address);
            await _cityField.FillAsync(owner.City);
            await _telephoneField.FillAsync(owner.Telephone);

            var responseTask = _page.WaitForResponseAsync(response =>
            response.Url.Contains("/api/owners") &&
            response.Request.Method == "POST");

            await _addOwnerButton.ClickAsync();

            var response = await responseTask;

            var json = await response.TextAsync();

            var createdOwner = JsonSerializer.Deserialize<Owner>(json);

            owner.Id = createdOwner!.Id;

            _logger.Information($"Owner created with ID {owner.Id}");

            return owner;
        }

        public async Task IsOpen()
        {
            _page.Url.Should().Be(FullUrl);

            var text = await _newOwnerText.TextContentAsync();
            text.Should().Be(" New Owner ");
        }
    }
}