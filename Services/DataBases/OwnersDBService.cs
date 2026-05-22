using PetClinicTests.Common.Configuration;
using PetClinicTests.Common.DBConnector;
using PetClinicTests.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace PetClinicTests.Services.DataBases
{
    public class OwnersDBService
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        private readonly PetClinicDBConnector _dbConnector;

        public OwnersDBService(PetClinicDBConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public OwnersTable? GetLastAddedOwner()
        {
            var owner = _dbConnector.OwnersTable.OrderByDescending(p => p.Id).First();
            _logger.Information($"Last owner Id is {owner.Id} in DB");

            return owner;
        }
    }
}
