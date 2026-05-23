using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using Serilog;

namespace PetClinicTests.Pages
{
    public class MenuBar: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public MenuBar(IPage page) : base(page) => END_POINT = "";

        private ILocator _homeButton => _page.GetByRole(AriaRole.Link, new () {Name = "Home" });
        private ILocator _ownersDropDown => _page.GetByRole(AriaRole.Button, new() {Name = "Owners"});
        private ILocator _ownersSearchButton => _page.GetByRole(AriaRole.Link, new() { Name = "Search" });
        private ILocator _ownersAddButton => _page.GetByRole(AriaRole.Link, new() { Name = "Add New" });
        private ILocator _veterinariansDropDown => _page.GetByRole(AriaRole.Button, new() {Name = "Veterinarians" });
        private ILocator _veterinariansAllButton => _page.GetByRole(AriaRole.Link, new() { Name = "All" });
        private ILocator _veterinariansAddButton => _page.GetByRole(AriaRole.Link, new() { Name = "Add New" });
        private ILocator _petTypesButton => _page.GetByRole(AriaRole.Link, new() { Name = "Pet Types" });
        private ILocator _specialtiesButton => _page.GetByRole(AriaRole.Link, new() { Name = "Specialties" });

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public async Task ClickHomeButton()
        {
            await _homeButton.ClickAsync();

            _logger.Information("Home Page is open.");
        }

        public async Task OpenOwnersDropDown()
        {
            await _ownersDropDown.ClickAsync();
        }

        public async Task ClickOwnersSearchButton()
        {
            await OpenOwnersDropDown();
            await _ownersSearchButton.ClickAsync();

            _logger.Information("Owners Page is open.");
        }

        public async Task ClickOwnersAddButton()
        {
            await OpenOwnersDropDown();
            await _ownersAddButton.ClickAsync();

            _logger.Information("Add New Owner Page is open.");
        }

        public async Task OpenVeterinariansDropDown()
        {
            await _veterinariansDropDown.ClickAsync();
        }

        public async Task ClickVeterinariansAllButton()
        {
            await OpenVeterinariansDropDown();
            await _veterinariansAllButton.ClickAsync();

            _logger.Information("Veterinarians Page is open.");
        }

        public async Task ClickVeterinariansAddButton()
        {
            await OpenVeterinariansDropDown();
            await _veterinariansAddButton.ClickAsync();

            _logger.Information("Add New Veterinarian Page is open.");
        }

        public async Task ClickPetTypesButton()
        {
            await _petTypesButton.ClickAsync();

            _logger.Information("Pet Types Page is open.");
        }

        public async Task ClickSpecialtiesButton()
        {
            await _specialtiesButton.ClickAsync();

            _logger.Information("Specialties Page is open.");
        }
    }
}