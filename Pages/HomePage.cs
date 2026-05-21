using Microsoft.Playwright;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace PetClinicTests.Pages
{
    public abstract class HomePage: BasePage
    {
        public HomePage(IPage page) : base(page) => END_POINT = "welcome";

        private ILocator _welcomeToPetclinicText => _page.GetByRole('heading',{name:'Welcome to Petclinic'});
        private ILocator _welcomeText => _page.GetByRole('heading',{name:'Welcome',exact:true});
        private ILocator _welcomeImage => _page.GetByRole('img',{name:'pets logo'});

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public async Task GetWelcomePictureandText()
        {
            await _welcomeToPetclinicText;
            await _passwordInput.FillAsync(user.Password);
            await _logInButton.ClickAsync();
            await _userloginButton(user).IsEnabledAsync();
        }

        public async Task WaitForHomePage()
        {
            await _userNameInput.WaitForAsync();
        }
    }
}