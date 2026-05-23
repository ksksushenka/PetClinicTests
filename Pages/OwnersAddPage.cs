using FluentAssertions;
using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using Serilog;

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
        private ILocator _backButton => _page.GetByRole(AriaRole.Button, new() { Name = "Back" });
        private ILocator _addOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Owner" });

        public async Task<OwnersAddPage> NavigateToOwnersAddPage()
        {
            await _page.GotoAsync(FullUrl);
            _logger.Information($"Navigated to {FullUrl}");

            await _newOwnerText.WaitForAsync();

            return this;
        }

        // Methods
        public async Task CreateNewOwner(string firstName, string lastName, string address, string city, string phone)
        {
            await NavigateToOwnersAddPage();
            await _firstNameField.FillAsync(firstName);
            await _lastNameField.FillAsync(lastName);
            await _addressField.FillAsync(address);
            await _cityField.FillAsync(city);
            await _telephoneField.FillAsync(phone);
            await _addOwnerButton.ClickAsync();

            _logger.Information("Owner is created.");
        }

        public async Task IsOpen()
        {
            _page.Url.Should().Be(FullUrl);

            var text = await _newOwnerText.TextContentAsync();
            text.Should().Be(" New Owner ");
        }
    }
}