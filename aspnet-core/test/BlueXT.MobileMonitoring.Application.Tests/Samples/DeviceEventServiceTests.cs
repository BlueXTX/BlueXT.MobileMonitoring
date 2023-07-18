using System;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.DeviceEvents;
using Bogus;
using FluentAssertions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;
using Xunit;

namespace BlueXT.MobileMonitoring.Samples;

/// <summary>
/// Тесты для <see cref="DeviceEventService"/>.
/// </summary>
public sealed class DeviceEventServiceTests : MobileMonitoringApplicationTestBase
{
    private readonly Faker _faker = new();
    private readonly DeviceEventService _deviceEventService;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public DeviceEventServiceTests() => _deviceEventService = GetRequiredService<DeviceEventService>();

    /// <summary>
    /// <see cref="DeviceEventService.CreateAsync"/> с валидным DTO должно возвращать <see cref="DeviceEventDto"/>.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task CreateAsync_WithValidDto_ShouldReturnEntity()
    {
        var createdEntity = await CreateEntity();

        createdEntity.Should().NotBeNull();
    }

    /// <summary>
    /// <see cref="DeviceEventService.CreateAsync"/> с невалидным DTO должен выбрасывать <see cref="AbpValidationException"/>.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task CreateAsync_WithInvalidDto_ShouldThrow()
    {
        var dto = new CreateOrUpdateDeviceEventDto
        {
            Name = string.Empty,
        };
        var act = () => _deviceEventService.CreateAsync(dto);

        await act.Should().ThrowAsync<AbpValidationException>();
    }

    /// <summary>
    /// <see cref="DeviceEventService.GetAsync"/> с существующим id должен возвращать <see cref="DeviceEventDto"/>.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task GetAsync_WithExistingId_ShouldNotBeNull()
    {
        var createdEntity = await CreateEntity();
        var entity = await _deviceEventService.GetAsync(createdEntity.Id);

        entity.Should().NotBeNull();
        entity.Name.Should().Be(createdEntity.Name);
    }

    /// <summary>
    /// <see cref="DeviceEventService.GetAsync"/> с несуществующим id должен выбрасывать <see cref="EntityNotFoundException"/>.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task GetAsync_WithNonExistentId_ShouldNotBeNull()
    {
        var act = () => _deviceEventService.GetAsync(Guid.Empty);
        await act.Should().ThrowAsync<EntityNotFoundException>();
    }

    /// <summary>
    /// <see cref="DeviceEventService.UpdateAsync"/> с существующим id должен обновлять сущность.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task UpdateAsync_WithExistingId_ShouldUpdate()
    {
        const string UpdatedName = "Updated name";
        var createdEntity = await CreateEntity();
        var updateDto = new CreateOrUpdateDeviceEventDto
        {
            Name = UpdatedName,
        };

        var updatedEntity = await _deviceEventService.UpdateAsync(createdEntity.Id, updateDto);

        updatedEntity.Name.Should().Be(UpdatedName);
    }

    /// <summary>
    /// <see cref="DeviceEventService.UpdateAsync"/> с несуществующим id должен выбрасывать <see cref="EntityNotFoundException"/>.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task UpdateAsync_WithNonExistentId_ShouldThrow()
    {
        var updateDto = new CreateOrUpdateDeviceEventDto
        {
            Name = "updated name",
        };
        var act = () => _deviceEventService.UpdateAsync(Guid.Empty, updateDto);
        await act.Should().ThrowAsync<EntityNotFoundException>();
    }

    /// <summary>
    /// <see cref="DeviceEventService.DeleteAsync"/> с существующим id должен удалять сущность.
    /// </summary>
    /// <returns>Тест.</returns>
    [Fact]
    public async Task Delete_WithExistingId_ShouldDelete()
    {
        var createdEntity = await CreateEntity();
        await _deviceEventService.DeleteAsync(createdEntity.Id);
    }

    private async Task<DeviceEventDto> CreateEntity() =>
        await _deviceEventService.CreateAsync(
            new CreateOrUpdateDeviceEventDto
            {
                Name = _faker.Lorem.Word(),
            });
}
