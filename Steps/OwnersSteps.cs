using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using PetClinicTests.Pages;
using Serilog;

namespace PetClinicTests.Steps
{
    public class OwnersSteps : BaseStep
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        private HomePage HomePage => new HomePage(_page);
        private MenuBar MenuBar => new MenuBar(_page);
        private OwnersPage OwnersPage => new OwnersPage(_page);
        private OwnersAddPage OwnersAddPage => new OwnersAddPage(_page);

        public OwnersSteps(IPage page) : base(page)
        {

        }

        //public async Task AddNewOwner(string firstName, string lastName, string address, string city, string phone)
        //{
        //    await HomePage.NavigateToHomePage();
        //    await MenuBar.ClickOwnersSearchLink();
        //    await OwnersPage.ClickAddNewOwnerButton();
        //    await OwnersAddPage.CreateNewOwner(firstName, lastName, address, city, phone);
        //}
    }
}
