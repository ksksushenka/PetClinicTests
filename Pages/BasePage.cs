using Microsoft.Playwright;

namespace PetClinicTests.Pages
{
    public abstract class BasePage
    {
        protected string END_POINT;

        protected IPage _page;

        public BasePage(IPage page) => _page = page;

        protected abstract string GetEndpoint();

        public async Task GotoAsync()
        {
            await _page.GotoAsync(Environment.GetEnvironmentVariable("URL") + GetEndpoint());
        }
    }
}
