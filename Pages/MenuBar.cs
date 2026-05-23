using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using Serilog;

namespace PetClinicTests.Pages
{
    public class MenuBar: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public MenuBar(IPage page) : base(page) {}
        protected override string Endpoint => "";

        private ILocator _homeLink => _page.GetByRole(AriaRole.Link, new () {Name = "Home" });
        private ILocator _ownersDropDown => _page.GetByRole(AriaRole.Button, new() {Name = "Owners"});
        private ILocator _ownersSearchLink => _page.GetByRole(AriaRole.Link, new() { Name = "Search" });
        private ILocator _ownersAddLink => _page.GetByRole(AriaRole.Link, new() { Name = "Add New" });
        private ILocator _veterinariansDropDown => _page.GetByRole(AriaRole.Button, new() {Name = "Veterinarians" });
        private ILocator _veterinariansAllLink => _page.GetByRole(AriaRole.Link, new() { Name = "All" });
        private ILocator _veterinariansAddLink => _page.GetByRole(AriaRole.Link, new() { Name = "Add New" });
        private ILocator _petTypesLink => _page.GetByRole(AriaRole.Link, new() { Name = "Pet Types" });
        private ILocator _specialtiesLink => _page.GetByRole(AriaRole.Link, new() { Name = "Specialties" });

        public async Task<MenuBar> NavigateToMainPage()
        {
            await _page.GotoAsync(FullUrl);
            _logger.Information($"Navigated to {FullUrl}");

            return this;
        }

        public async Task ClickHomeLink()
        {
            await _homeLink.ClickAsync();

            _logger.Information("Home Page is open.");
        }

        public async Task OpenOwnersDropDown()
        {
            await _ownersDropDown.ClickAsync();
        }

        public async Task ClickOwnersSearchLink()
        {
            await OpenOwnersDropDown();
            await _ownersSearchLink.ClickAsync();

            _logger.Information("Owners Page is open.");
        }

        public async Task ClickOwnersAddLink()
        {
            await OpenOwnersDropDown();
            await _ownersAddLink.ClickAsync();

            _logger.Information("Add New Owner Page is open.");
        }

        public async Task OpenVeterinariansDropDown()
        {
            await _veterinariansDropDown.ClickAsync();
        }

        public async Task ClickVeterinariansAllLink()
        {
            await OpenVeterinariansDropDown();
            await _veterinariansAllLink.ClickAsync();

            _logger.Information("Veterinarians Page is open.");
        }

        public async Task ClickVeterinariansAddLink()
        {
            await OpenVeterinariansDropDown();
            await _veterinariansAddLink.ClickAsync();

            _logger.Information("Add New Veterinarian Page is open.");
        }

        public async Task ClickPetTypesLink()
        {
            await _petTypesLink.ClickAsync();

            _logger.Information("Pet Types Page is open.");
        }

        public async Task ClickSpecialtiesLink()
        {
            await _specialtiesLink.ClickAsync();

            _logger.Information("Specialties Page is open.");
        }
    }
}