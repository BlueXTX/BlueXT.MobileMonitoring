using BlueXT.MobileMonitoring.DeviceStatistics;
using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace BlueXT.MobileMonitoring.Dapper.Repositories;

public class DapperDeviceStatisticRepository : DapperRepository<MobileMonitoringDbContext>, IDeviceStatisticRepository, ITransientDependency
{
    public DapperDeviceStatisticRepository(IDbContextProvider<MobileMonitoringDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public Task<List<DeviceStatistic>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task<long> GetCountAsync(CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task<List<DeviceStatistic>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = new()) =>
        throw new NotImplementedException();

    public Task<DeviceStatistic> InsertAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task InsertManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task<DeviceStatistic> UpdateAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task UpdateManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task<DeviceStatistic> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task<DeviceStatistic> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteManyAsync(IEnumerable<Guid> ids, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();
}
