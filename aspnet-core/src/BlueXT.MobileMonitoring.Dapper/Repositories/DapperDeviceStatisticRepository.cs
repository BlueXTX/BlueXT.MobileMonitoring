using BlueXT.MobileMonitoring.DeviceStatistics;
using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Dapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Guids;

namespace BlueXT.MobileMonitoring.Dapper.Repositories;

/// <summary>
/// Dapper репозиторий для работы с <see cref="DeviceStatistic"/>.
/// </summary>
public class DapperDeviceStatisticRepository : DapperRepository<MobileMonitoringDbContext>, IDeviceStatisticRepository, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContextProvider">Провайдер контекста базы данных.</param>
    /// <param name="guidGenerator">Генератор уникальных идентификаторов.</param>
    public DapperDeviceStatisticRepository(IDbContextProvider<MobileMonitoringDbContext> dbContextProvider, IGuidGenerator guidGenerator)
        : base(dbContextProvider) => _guidGenerator = guidGenerator;

    /// <summary>
    /// Получить список сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список сущностей.</returns>
    /// <exception cref="NotImplementedException">Метод ее реализован.</exception>
    public Task<List<DeviceStatistic>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Получить количество сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Количество сущностей.</returns>
    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
    {
        const string Sql = "SELECT COUNT(*) FROM app_device_statistic";
        var connection = await GetDbConnectionAsync();
        return await connection.ExecuteScalarAsync<int>(Sql, await GetDbTransactionAsync());
    }

    /// <summary>
    /// Получить постраничный список сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="skipCount">Число пропускаемых значений.</param>
    /// <param name="maxResultCount">Максимальное количество значений.</param>
    /// <param name="sorting">Сортировка.</param>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Постраничный список сущностей.</returns>
    public async Task<List<DeviceStatistic>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        const string Sql = @"SELECT * FROM app_device_statistic OFFSET @Offset LIMIT @Limit;";
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

    /// <summary>
    /// Добавить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="autoSave">Сохранять после добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленная сущность.</returns>
    public async Task<DeviceStatistic> InsertAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        const string Sql = @"INSERT INTO app_device_statistic (id, device_id, username, operating_system, app_version) VALUES (@Id, @DeviceId, @Username, @OperatingSystem, @AppVersion) RETURNING *;";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(
            Sql,
            new
            {
                Id = _guidGenerator.Create(),
                entity.DeviceId,
                entity.Username,
                entity.OperatingSystem,
                entity.AppVersion,
            },
            await GetDbTransactionAsync());
    }

    /// <summary>
    /// Добавить несколько сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="entities">Сущности.</param>
    /// <param name="autoSave">Сохранять после добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача добавления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task InsertManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Обновить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="entity">Сущность для обновления.</param>
    /// <param name="autoSave">Сохранять после обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность.</returns>
    public async Task<DeviceStatistic> UpdateAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = default) => await UpdateAsync(entity.Id, entity, cancellationToken);

    /// <summary>
    /// Обновить несколько сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="entities">Сущности для обновления.</param>
    /// <param name="autoSave">Сохранять после обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача обновления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task UpdateManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Удалить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="entity">Сущность для удаления.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    public async Task DeleteAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = default) => await DeleteAsync(entity.Id, cancellationToken: cancellationToken);

    /// <summary>
    /// Удалить несколько сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="entities">Сущности для удаления.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task DeleteManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Получить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность.</returns>
    public async Task<DeviceStatistic> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        const string Sql = "SELECT * FROM app_device_statistic WHERE id = @Id";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(Sql, new { Id = id }, await GetDbTransactionAsync());
    }

    /// <summary>
    /// Поиск сущности <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Найденная сущность.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task<DeviceStatistic> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Удалить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    public async Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        const string Sql = @"DELETE FROM app_device_statistic WHERE id = @Id";
        var connection = await GetDbConnectionAsync();
        await connection.ExecuteAsync(Sql, new { Id = id }, await GetDbTransactionAsync());
    }

    /// <summary>
    /// Удалить несколько сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="ids">Уникальные идентификаторы.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task DeleteManyAsync(IEnumerable<Guid> ids, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Обновить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="entity">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность.</returns>
    public async Task<DeviceStatistic> UpdateAsync(Guid id, DeviceStatistic entity, CancellationToken cancellationToken = default)
    {
        const string Sql = @"UPDATE app_device_statistic SET device_id = @DeviceId, username = @Username, operating_system = @OperatingSystem, app_version = @AppVersion WHERE id = @Id RETURNING *;";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(
            Sql,
            new
            {
                entity.DeviceId,
                entity.Username,
                entity.OperatingSystem,
                entity.AppVersion,
                Id = id,
            },
            await GetDbTransactionAsync());
    }

    /// <inheritdoc cref="IDeviceStatisticRepository.GetByDeviceId"/>
    public async Task<DeviceStatistic> GetByDeviceId(Guid deviceId, CancellationToken cancellationToken = default)
    {
        const string Sql = @"SELECT * FROM app_device_statistic WHERE device_id = @DeviceId";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(
            Sql,
            new
            {
                deviceId,
            },
            await GetDbTransactionAsync()
        );
    }
}
