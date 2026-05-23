using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using Serilog;

namespace PetClinicTests.Pages
{
    public class OwnersPage: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public OwnersPage(IPage page) : base(page) => END_POINT = "owners";

        private ILocator _ownersText => _page.GetByRole(AriaRole.Heading, new() { Name = "Owners" });
        private ILocator _addNewOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Owner" });
        private ILocator _lastNameInput => _page.Locator("#lastName");
        private ILocator _findOwnerButton => _page.GetByRole(AriaRole.Button, new() { Name = "Find Owner" });
        private ILocator _ownerFullNameLink(string ownerName) => _page.GetByRole(AriaRole.Link, new() { Name = ownerName });

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public async Task<OwnersPage> NavigateToOwnersPage()
        {
            await _page.GotoAsync(Environment.GetEnvironmentVariable("URL") + GetEndpoint());
            _logger.Information($"Navigated to {Environment.GetEnvironmentVariable("URL") + GetEndpoint()}");

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

        public async Task ClickOnOwner(string ownerName)
        {
            await _ownerFullNameLink(ownerName).ClickAsync();

            _logger.Information("Owner Information Page is open.");
        }

        public async Task ClickAddNewOwnerButton()
        {
            await _addNewOwnerButton.ClickAsync();

            _logger.Information("Add New Owner Page is open.");
        }
    }
}