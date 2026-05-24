using FluentAssertions;
using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using PetClinicTests.Models.Petclinic;
using Serilog;

namespace PetClinicTests.Pages
{
    public class OwnersEditPage: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();
        private readonly int ownerId;

        public OwnersEditPage(IPage page) : base(page) { }
        protected override string Endpoint => $"owners/{ownerId}/edit";

        private ILocator _newOwnerText => _page.GetByRole(AriaRole.Heading, new() { Name = "Edit Owner" });
        private ILocator _firstNameField => _page.GetByRole(AriaRole.Textbox, new () {Name = "First Name"});
        private ILocator _lastNameField => _page.GetByRole(AriaRole.Textbox, new() {Name = "Last Name"});
        private ILocator _addressField => _page.GetByRole(AriaRole.Textbox, new() {Name = "Address" });
        private ILocator _cityField => _page.GetByRole(AriaRole.Textbox, new() { Name = "City" });
        private ILocator _telephoneField => _page.GetByRole(AriaRole.Textbox, new() { Name = "Telephone" });
        private ILocator _updateOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Update Owner" });

        // Methods
        public async Task EditOwner(Owner owner)
        {
            await _firstNameField.FillAsync(owner.FirstName);
            await _lastNameField.FillAsync(owner.LastName);
            await _addressField.FillAsync(owner.Address);
            await _cityField.FillAsync(owner.City);
            await _telephoneField.FillAsync(owner.Telephone);

            var responseTask = _page.WaitForResponseAsync(response =>
                response.Url.Contains("/api/owners/") &&
                response.Request.Method == "PUT"
            );

            await _updateOwnerButton.ClickAsync();

            var response = await responseTask;

            response.Ok.Should().BeTrue();

            _logger.Information("Owner is updated.");
        }

        public async Task IsOpen()
        {
            _page.Url.Should().Be(FullUrl);

            var text = await _newOwnerText.TextContentAsync();
            text.Should().Be(" New Owner ");
        }
    }
}