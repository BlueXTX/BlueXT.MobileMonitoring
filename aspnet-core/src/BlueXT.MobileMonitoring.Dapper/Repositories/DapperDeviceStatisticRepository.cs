using BlueXT.MobileMonitoring.DeviceStatistics;
using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Dapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Guids;
using Volo.Abp.Timing;

namespace BlueXT.MobileMonitoring.Dapper.Repositories;

/// <summary>
/// Dapper репозиторий для работы с <see cref="DeviceStatistic"/>.
/// </summary>
public class DapperDeviceStatisticRepository : DapperRepository<MobileMonitoringDbContext>, IDeviceStatisticRepository, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IClock _clock;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContextProvider">Провайдер контекста базы данных.</param>
    /// <param name="guidGenerator">Генератор уникальных идентификаторов.</param>
    /// <param name="clock">Часы.</param>
    public DapperDeviceStatisticRepository(IDbContextProvider<MobileMonitoringDbContext> dbContextProvider, IGuidGenerator guidGenerator, IClock clock)
        : base(dbContextProvider)
    {
        _guidGenerator = guidGenerator;
        _clock = clock;
    }

    /// <summary>
    /// Получить список сущностей.
    /// </summary>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список сущностей.</returns>
    /// <exception cref="NotImplementedException">Метод ее реализован.</exception>
    public Task<List<DeviceStatistic>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Получить количество сущностей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Количество сущностей.</returns>
    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
    {
        const string Sql = "SELECT COUNT(*) FROM app_device_statistic WHERE is_deleted = false";
        var connection = await GetDbConnectionAsync();
        return await connection.ExecuteScalarAsync<int>(Sql, await GetDbTransactionAsync());
    }

    /// <summary>
    /// Получить постраничный список сущностей.
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

    /// <summary>
    /// Добавить сущность.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="autoSave">Сохранять после добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленная сущность.</returns>
    public async Task<DeviceStatistic> InsertAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        const string Sql = @"INSERT INTO app_device_statistic (id, device_id, username, operating_system, app_version, creation_time) VALUES (@Id, @DeviceId, @Username, @OperatingSystem, @AppVersion, @CreationTime) RETURNING *;";
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
                CreationTime = _clock.Now,
            },
            await GetDbTransactionAsync());
    }

    /// <summary>
    /// Добавить несколько сущностей.
    /// </summary>
    /// <param name="entities">Сущности.</param>
    /// <param name="autoSave">Сохранять после добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача добавления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task InsertManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="entity">Сущность для обновления.</param>
    /// <param name="autoSave">Сохранять после обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность.</returns>
    public async Task<DeviceStatistic> UpdateAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = default) => await UpdateAsync(entity.Id, entity, cancellationToken);

    /// <summary>
    /// Обновить несколько сущностей.
    /// </summary>
    /// <param name="entities">Сущности для обновления.</param>
    /// <param name="autoSave">Сохранять после обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача обновления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task UpdateManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="entity">Сущность для удаления.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    public async Task DeleteAsync(DeviceStatistic entity, bool autoSave = false, CancellationToken cancellationToken = default) => await DeleteAsync(entity.Id, cancellationToken: cancellationToken);

    /// <summary>
    /// Удалить несколько сущностей.
    /// </summary>
    /// <param name="entities">Сущности для удаления.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task DeleteManyAsync(IEnumerable<DeviceStatistic> entities, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Получить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность.</returns>
    public async Task<DeviceStatistic> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        const string Sql = "SELECT * FROM app_device_statistic WHERE id = @Id and is_deleted = false";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(Sql, new { Id = id }, await GetDbTransactionAsync());
    }

    /// <summary>
    /// Поиск сущности.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="includeDetails">Включать детали в выборку.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Найденная сущность.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task<DeviceStatistic> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    public async Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        const string Sql = @"UPDATE app_device_statistic SET is_deleted = true, deletion_time = @DeletionTime WHERE id = @Id";
        var connection = await GetDbConnectionAsync();
        await connection.ExecuteAsync(Sql, new { Id = id, DeletionTime = _clock.Now }, await GetDbTransactionAsync());
    }

    /// <summary>
    /// Удалить несколько сущностей.
    /// </summary>
    /// <param name="ids">Уникальные идентификаторы.</param>
    /// <param name="autoSave">Сохранять после удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача удаления.</returns>
    /// <exception cref="NotImplementedException">Не реализовано.</exception>
    public Task DeleteManyAsync(IEnumerable<Guid> ids, bool autoSave = false, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="entity">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность.</returns>
    public async Task<DeviceStatistic> UpdateAsync(Guid id, DeviceStatistic entity, CancellationToken cancellationToken = default)
    {
        const string Sql = @"UPDATE app_device_statistic SET device_id = @DeviceId, username = @Username, operating_system = @OperatingSystem, app_version = @AppVersion, last_modification_time = @LastModificationTime WHERE id = @Id and is_deleted = false RETURNING *;";
        var connection = await GetDbConnectionAsync();
        return await connection.QuerySingleAsync<DeviceStatistic>(
            Sql,
            new
            {
                entity.DeviceId,
                entity.Username,
                entity.OperatingSystem,
                entity.AppVersion,
                LastModificationTime = _clock.Now,
                Id = id,
            },
            await GetDbTransactionAsync());
    }
}
