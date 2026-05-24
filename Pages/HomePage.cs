using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using Serilog;

namespace PetClinicTests.Pages
{
    public class HomePage: BasePage
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        public HomePage(IPage page) : base(page) { }
        protected override string Endpoint => "welcome";

        private ILocator _welcomeToPetclinicText => _page.GetByRole(AriaRole.Heading, new () {Name = "Welcome to Petclinic"});
        private ILocator _welcomeText => _page.GetByRole(AriaRole.Heading, new() {Name = "Welcome", Exact = true});
        private ILocator _welcomeImage => _page.GetByRole(AriaRole.Img, new() {Name = "pets logo"});

        public async Task<HomePage> NavigateToHomePage()
        {
            await _page.GotoAsync(FullUrl);
            _logger.Information($"Navigated to {FullUrl}");

            await _welcomeToPetclinicText.WaitForAsync();

            return this;
        }

        public async Task IsOpen()
        {
            _page.Url.Should().Be(FullUrl);

            var text1 = await _welcomeToPetclinicText.TextContentAsync();
            var text2 = await _welcomeText.TextContentAsync();
            var imageIsVisible = await _welcomeImage.IsVisibleAsync();

            using (new AssertionScope())
            {
                text1.Should().Be("Welcome to Petclinic");
                text2.Should().Be("Welcome");
                imageIsVisible.Should().BeTrue();
            }
        }
    }
}