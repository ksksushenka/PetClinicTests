using Microsoft.Playwright;

namespace PetClinicTests.Services.API
{
    public abstract class BaseService
    {
        protected IPlaywright _playwright;
        protected IAPIRequestContext _request;

        //private static readonly string POST_Authorization = "api/Auth";

        protected BaseService(IPlaywright playwright)
        {
            _request = playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = Environment.GetEnvironmentVariable("PetclinicAPI"),
                ExtraHTTPHeaders = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                }
            }).GetAwaiter().GetResult();
        }

        //protected async Task<string> GetBearer()
        //{
        //    var headers = new Dictionary<string, string>();

        //    headers.Add("Content-Type", "application/json");
        //    headers.Add("userName", Configurator.GetAuthUser.Username);
        //    headers.Add("password", Configurator.GetAuthUser.Password);

        //    var request = await this._playwright.APIRequest.NewContextAsync(new()
        //    {
        //        BaseURL = Environment.GetEnvironmentVariable("API"),
        //        ExtraHTTPHeaders = headers,
        //    });

        //    var response = await request.PostAsync(POST_Authorization);
        //    var bearer = response.JsonAsync().Result.Value.GetProperty("accessToken").ToString();

        //    return bearer;
        //}
    }
}

