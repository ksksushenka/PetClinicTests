using FluentAssertions;
using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using Serilog;

namespace PetClinicTests.Pages
{
    public class OwnersPage: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public OwnersPage(IPage page) : base(page) { }
        protected override string Endpoint => "owners";

        private ILocator _ownersText => _page.GetByRole(AriaRole.Heading, new() { Name = "Owners" });
        private ILocator _addNewOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Owner" });
        private ILocator _lastNameInput => _page.Locator("#lastName");
        private ILocator _findOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Find Owner" });
        private ILocator _ownerFullNameLink(string ownerName) => _page.GetByRole(AriaRole.Link, new() { Name = ownerName });

        public async Task<OwnersPage> NavigateToOwnersPage()
        {
            await _page.GotoAsync(FullUrl);
            _logger.Information($"Navigated to {FullUrl}");

            await _ownersText.WaitForAsync();

            return this;
        }

        // Methods
        public async Task FindOwnerbyLastName(string lastName)
        {
            await _lastNameInput.FillAsync(lastName);
            await _findOwnerButton.ClickAsync();

            _logger.Information("Owner search.");
        }

        public async Task ClickOnOwner(string ownerFullName)
        {
            await _ownerFullNameLink(ownerFullName).ClickAsync();

            _logger.Information("Owner Information Page is open.");
        }

        public async Task ClickAddNewOwnerButton()
        {
            await _addNewOwnerButton.ClickAsync();

            _logger.Information("Add New Owner Page is open.");
        }

        public async Task IsOpen()
        {
            _page.Url.Should().Be(FullUrl);
            
            var text = await _ownersText.TextContentAsync();
            text.Should().Be("Owners");
        }
    }
}