using FluentAssertions;
using FluentAssertions.Execution;
using PetClinicTests.Steps;

namespace PetClinicTests.Tests.UI
{
    public class HomePageTests : BaseTest
    {
        private HomeSteps HomeSteps;

        private string? firstText;
        private string? secondText;

        [SetUp]
        public void InitHomeSteps()
        {
            HomeSteps = new HomeSteps(Page);
        }

        [Test]
        public async Task VerifyOpeningHomePage()
        {
            //Open Home Page
            await HomeSteps.OpenHomePage();

            firstText = await HomePage.GetWelcomeToPetclinicText();
            secondText = await HomePage.GetWelcomeText();

            //Assertion
            using (new AssertionScope())
            {
                firstText.Should().Be("Welcome to Petclinic");
                secondText.Should().Be("Welcome");
            }
        }
    }
}
