using Microsoft.Playwright;
using PetClinicTests.Pages;

namespace PetClinicTests.Steps
{
    public class BaseStep
    {
        protected IPage _page;

        protected HomePage HomePage => new HomePage(_page);

        public BaseStep(IPage page) => _page = page;
    }
}
