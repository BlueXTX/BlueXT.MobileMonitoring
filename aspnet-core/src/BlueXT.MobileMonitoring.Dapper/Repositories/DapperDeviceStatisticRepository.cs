using BlueXT.MobileMonitoring.DeviceStatistics;
using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Dapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Guids;
using Volo.Abp.Timing;

namespace BlueXT.MobileMonitoring.Dapper.Repositories;

public class DapperDeviceStatisticRepository : DapperRepository<MobileMonitoringDbContext>, IDeviceStatisticRepository, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IClock _clock;

    public DapperDeviceStatisticRepository(IDbContextProvider<MobileMonitoringDbContext> dbContextProvider, IGuidGenerator guidGenerator, IClock clock)
        : base(dbContextProvider)
    {
        _guidGenerator = guidGenerator;
        _clock = clock;
    }

    public Task<List<DeviceStatistic>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = new())
    {
        const string Sql = "SELECT COUNT(*) FROM app_device_statistic WHERE is_deleted = false";
        var connection = await GetDbConnectionAsync();
        return await connection.ExecuteScalarAsync<int>(Sql, await GetDbTransactionAsync());
    }

    public async Task<List<DeviceStatistic>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = new())
    {
        const string Sql = @"SELECT * FROM app_device_statistic WHERE is_deleted = false OFFSET @Offset LIMIT @Limit;";
        var connection = await GetDbConnectionAsync();
        return (await connection.QueryAsync<DeviceStatistic>(
            Sql,
            new
            {
                Offset = skipCount,
                Limit = maxResultCount,
            },
            await GetDbTransactionAsync())).ToList();
    }

    public async Task<DeviceStatistic> InsertAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = new())
    {
        const string Sql = @"INSERT INTO app_device_statistic (id, device_id, username, operating_system, app_version, creation_time) VALUES (@Id, @DeviceId, @Username, @OperatingSystem, @AppVersion, @CreationTime) RETURNING *;";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(
            Sql,
            new
            {
                Id = _guidGenerator.Create(),
                DeviceId = entity.DeviceId,
                Username = entity.Username,
                OperatingSystem = entity.OperatingSystem,
                AppVersion = entity.AppVersion,
                CreationTime = _clock.Now,
            },
            await GetDbTransactionAsync());
    }

    public Task InsertManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task<DeviceStatistic> UpdateAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task UpdateManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public async Task<DeviceStatistic> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = new())
    {
        const string Sql = "SELECT * FROM app_device_statistic WHERE id = @Id";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(Sql, new { Id = id }, await GetDbTransactionAsync());
    }

    public Task<DeviceStatistic> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();

    public Task DeleteManyAsync(IEnumerable<Guid> ids, bool autoSave = false, CancellationToken cancellationToken = new()) => throw new NotImplementedException();
}
