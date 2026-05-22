using PetClinicTests.Core.Client;

namespace PetClinicTests.Services.API
{
    public abstract class BaseRestSharpService
    {
        protected ApiClient _apiClient;

        public BaseRestSharpService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}
