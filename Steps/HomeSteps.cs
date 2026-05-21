using Microsoft.Playwright;

namespace PetClinicTests.Steps
{
    public class HomeSteps : BaseStep
    {
        public HomeSteps(IPage page) : base(page)
        {

        }

        public async Task OpenHomePage()
        {
            await HomePage.GotoAsync();
            await HomePage.GetWelcomePictureAndText();
        }
    }
}
