using Microsoft.Playwright;

namespace PetClinicTests.Pages
{
    public class MenuBar: BasePage
    {
        public MenuBar(IPage page) : base(page) => END_POINT = "";

        private ILocator _homeButton => _page.GetByRole(AriaRole.Link, new () {Name = "Home" });
        private ILocator _ownersDropDown => _page.GetByRole(AriaRole.Button, new() {Name = "Owners", Exact = true});
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
        }

        public async Task OpenOwnersDropDown()
        {
            await _ownersDropDown.ClickAsync();
        }

        public async Task ClickOwnersSearchButton()
        {
            await _ownersSearchButton.ClickAsync();
        }

        public async Task ClickOwnersAddButton()
        {
            await _ownersAddButton.ClickAsync();
        }

        public async Task OpenVeterinariansDropDown()
        {
            await _veterinariansDropDown.ClickAsync();
        }

        public async Task ClickVeterinariansAllButton()
        {
            await _veterinariansAllButton.ClickAsync();
        }

        public async Task ClickVeterinariansAddButton()
        {
            await _veterinariansAddButton.ClickAsync();
        }

        public async Task ClickPetTypesButton()
        {
            await _petTypesButton.ClickAsync();
        }

        public async Task ClickSpecialtiesAddButton()
        {
            await _specialtiesButton.ClickAsync();
        }
    }
}