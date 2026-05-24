using Microsoft.Playwright;
using PetClinicTests.Common.DBConnector;
using Allure.Net.Commons;

namespace PetClinicTests.Tests
{
    public class BaseTest : PageTest
    {
        protected PetClinicDBConnector _petClinicDBConnector;

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                ViewportSize = new()
                {
                    Width = Convert.ToInt32(TestContext.Parameters["ViewportWidth"]),
                    Height = Convert.ToInt32(TestContext.Parameters["ViewportHeight"])
                },
                RecordVideoDir = "videos/",
                RecordVideoSize = new RecordVideoSize() { Width = 1024, Height = 768 }
            };
        }

        [SetUp]
        public async Task StartTracing()
        {
            await Context.Tracing.StartAsync(new()
            {
                Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [SetUp]
        public async Task Initialization()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();

            Page.SetDefaultTimeout(60000);

            //Init DB connector
            _petClinicDBConnector = new PetClinicDBConnector();

            //Init Pages and Services
        }

        [TearDown]
        public async Task StopTracing()
        {
            await Context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.MethodName}.zip"
                )
            });
        }

        [TearDown]
        public void CloseBrowser()
        {
            //Close browser
            Page.CloseAsync();
            _petClinicDBConnector.Dispose();
        }

        [TearDown]
        public void AllureTearDown()
        {
            AllureLifecycle.Instance.StopTestCase();
            AllureLifecycle.Instance.WriteTestCase();
        }
    }
}
