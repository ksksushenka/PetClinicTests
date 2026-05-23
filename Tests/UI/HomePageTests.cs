using FluentAssertions;
using FluentAssertions.Execution;
using PetClinicTests.Common.DBConnector;
using PetClinicTests.Pages;

namespace PetClinicTests.Tests.UI
{
    public class HomePageTests : BaseTest
    {
        private string? firstText;
        private string? secondText;

        [SetUp]
        public async Task InitializationHomePage()
        {
            HomePage = new HomePage(Page);
        }

        [Test]
        public async Task VerifyOpeningHomePage()
        {
            //Open Home Page
            await HomePage.NavigateToHomePage();

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
