using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using PetClinicTests.Models.Petclinic;
using Serilog;
using System.Text.Json;
using Task = System.Threading.Tasks.Task;

namespace PetClinicTests.Services.API
{
    public class OwnerService : BaseService
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        private static readonly string GET_OWNER = "api/Owners?id=";
        private static readonly string POST_OWNER = "api/Owners";
        private static readonly string DELETE_OWNER = "api/Owners?id=";
        
        public OwnerService(IPlaywright playwright) : base(playwright)
        {
        }

        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            var response = await _request.PostAsync(POST_OWNER, new ()
            {
                DataObject = owner
            });

            var createdOwner = await response.JsonAsync<Owner>();

            _logger.Information($"Owner is created with id {owner.Id}.");

            return owner;
        }

        public async Task<Owner> GetOwnerAsync(int ownerId)
        {
            var response = await _request.GetAsync(GET_OWNER + ownerId);

            var owner = await response.JsonAsync<Owner>();

            _logger.Information($"Received owner with id {ownerId}.");

            return JsonSerializer.Deserialize<Owner>((await response.TextAsync()));
        }

        public async Task DeleteOwnerAsync(int ownerId)
        {
            var response = await _request.DeleteAsync(DELETE_OWNER + ownerId);

            _logger.Information($"Deleted owner with id {ownerId}.");
        }
    }
}
