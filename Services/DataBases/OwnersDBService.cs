using PetClinicTests.Common.Configuration;
using PetClinicTests.Common.DBConnector;
using Serilog;

namespace PetClinicTests.Services.DataBases
{
    public class OwnersDBService
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        private readonly PetClinicDBConnector _dbConnector;
    }
}
