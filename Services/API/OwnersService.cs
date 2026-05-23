using Microsoft.Playwright;
using PetClinicTests.Common.Configuration;
using PetClinicTests.Models.Petclinic;
using Serilog;
using System.Text.Json;
using Task = System.Threading.Tasks.Task;

namespace PetClinicTests.Services.API
{
    public class OwnersService : BaseService
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        private static readonly string GET_OWNER = "api/owners/";
        private static readonly string POST_OWNER = "api/owners";
        private static readonly string DELETE_OWNER = "api/owners/";
        
        public OwnersService(IPlaywright playwright) : base(playwright)
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

            _logger.Information($"Received owner with id {ownerId}.");

            return JsonSerializer.Deserialize<Owner>((await response.TextAsync()));
        }

        public async Task DeleteOwnerAsync(int ownerId)
        {
            var response = await _request.DeleteAsync(DELETE_OWNER + ownerId);

            _logger.Information($"Owner with id {ownerId} is deleted.");
        }
    }
}
