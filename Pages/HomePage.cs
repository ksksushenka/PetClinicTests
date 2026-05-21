using Microsoft.Playwright;

namespace PetClinicTests.Pages
{
    public class HomePage: BasePage
    {
        public HomePage(IPage page) : base(page) => END_POINT = "welcome";

        private ILocator _welcomeToPetclinicText => _page.GetByRole(AriaRole.Heading, new () {Name = "Welcome to Petclinic"});
        private ILocator _welcomeText => _page.GetByRole(AriaRole.Heading, new() {Name = "Welcome", Exact = true});
        private ILocator _welcomeImage => _page.GetByRole(AriaRole.Img, new() {Name = "pets logo"});

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public async Task GetWelcomePictureAndText()
        {
            await _welcomeToPetclinicText.IsVisibleAsync();
            await _welcomeText.IsVisibleAsync();
            await _welcomeImage.IsVisibleAsync();
        }

        public async Task<string?> GetWelcomeToPetclinicText()
        {
            return await _welcomeToPetclinicText.TextContentAsync();
        }

        public async Task<string?> GetWelcomeText()
        {
            return await _welcomeText.TextContentAsync();
        }
    }
}