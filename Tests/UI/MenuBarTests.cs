using PetClinicTests.Pages;

namespace PetClinicTests.Tests.UI
{
    [AllureNUnit]
    public class MenuBarTests : BaseTest
    {
        private MenuBar MenuBar;

        [SetUp]
        public async Task InitializationMenuBar()
        {
            MenuBar = new MenuBar(Page);
        }

        [Test]
        public async Task VerifyOpeningHomePage()
        {
            var homePage = new HomePage(Page);

            await MenuBar.NavigateToMainPage();
            await MenuBar.ClickHomeLink();
            await homePage.IsOpen();
        }

        [Test]
        public async Task VerifyOpeningOwnersPage()
        {
            var ownersPage = new OwnersPage(Page);

            await MenuBar.NavigateToMainPage();
            await MenuBar.ClickOwnersSearchLink();
            await ownersPage.IsOpen();
        }

        [Test]
        public async Task VerifyOpeningOwnerAddPage()
        {
            var ownersAddPage = new OwnersAddPage(Page);

            await MenuBar.NavigateToMainPage();
            await MenuBar.ClickOwnersAddLink();
            await ownersAddPage.IsOpen();
        }
    }
}
