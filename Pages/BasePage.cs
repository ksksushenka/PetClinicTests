using Microsoft.Playwright;

namespace PetClinicTests.Pages
{
    public abstract class BasePage
    {
        protected string END_POINT;
        protected string url;
        protected IPage _page;

        public BasePage(IPage page) => _page = page;

        protected abstract string Endpoint { get; }

        protected string BaseUrl => Environment.GetEnvironmentVariable("URL")!;

        protected string FullUrl => BaseUrl + Endpoint;

        public async Task GotoAsync()
        {
            await _page.GotoAsync(FullUrl);
        }
    }
}
