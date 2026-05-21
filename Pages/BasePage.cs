using Microsoft.Playwright;

namespace PetClinicTests.Pages
{
    public abstract class BasePage
    {
        protected string END_POINT;
        protected string url;
        protected IPage _page;

        public BasePage(IPage page) => _page = page;

        protected abstract string GetEndpoint();

        public async Task GotoAsync()
        {
            url = Environment.GetEnvironmentVariable("URL");
            await _page.GotoAsync(url + GetEndpoint());
        }
    }
}
