using Microsoft.Playwright;

namespace PetClinicTests.Common
{
    internal class WaitService
    {
        public static async Task IsElementNotVisible(ILocator locator)
        {
            var visible = true;

            for (int j = 0; j < 30; j++)
            {
                if (await locator.IsVisibleAsync() == true)
                {
                    visible = true;
                    Thread.Sleep(1000);
                    continue;
                }

                else
                {
                    visible = false;
                    break;
                }
            }

            if (visible == true) throw new Exception("Element is visible.");
        }

        public static async Task IsElementClickable(ILocator locator)
        {
            var clickable = false;

            for (int j = 0; j < 30; j++)
            {
                if (await locator.IsEditableAsync() == false)
                {
                    clickable = false;
                    Thread.Sleep(1000);
                    continue;
                }

                else
                {
                    clickable = true;
                    break;
                }
            }

            if (clickable == false) throw new Exception("Element is not clickable.");
        }
    }
}
