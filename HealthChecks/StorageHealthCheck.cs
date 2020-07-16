using Advertise.API.Services;
using Microsoft.Extensions.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Advertise.API.HealthChecks
{
    public class StorageHealthCheck : IHealthCheck
    {
        private readonly IAdvertStorageService _advertStorageService;

        public StorageHealthCheck(IAdvertStorageService advertStorageService)
        {
            _advertStorageService = advertStorageService;
        }
        public async ValueTask<IHealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)
        {
            var isStorageOk = await _advertStorageService.CheckHealthAsync();
            return HealthCheckResult.FromStatus(isStorageOk? CheckStatus.Healthy: CheckStatus.Unhealthy,"");
        }
    }
}
