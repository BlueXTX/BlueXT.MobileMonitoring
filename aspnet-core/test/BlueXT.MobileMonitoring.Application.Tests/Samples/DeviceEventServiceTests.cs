using System;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.DeviceEvents;
using Bogus;
using Shouldly;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;
using Xunit;

namespace BlueXT.MobileMonitoring.Samples;

public sealed class DeviceEventServiceTests : MobileMonitoringApplicationTestBase
{
    private readonly Faker _faker = new();
    private readonly DeviceEventService _deviceEventService;

    public DeviceEventServiceTests() => _deviceEventService = GetRequiredService<DeviceEventService>();

    [Fact]
    public async Task CreateAsync_WithValidDto_ShouldReturnEntity()
    {
        var createdEntity = await CreateEntity();

        createdEntity.ShouldNotBeNull();
    }

    [Fact]
    public async Task CreateAsync_WithInvalidDto_ShouldThrow()
    {
        var dto = new CreateOrUpdateDeviceEventDto
        {
            Name = string.Empty,
        };
        var act = () => _deviceEventService.CreateAsync(dto);

        await act.ShouldThrowAsync<AbpValidationException>();
    }

    [Fact]
    public async Task GetAsync_WithExistingId_ShouldNotBeNull()
    {
        var createdEntity = await CreateEntity();
        var entity = await _deviceEventService.GetAsync(createdEntity.Id);

        entity.ShouldNotBeNull();
        entity.Name.ShouldBe(createdEntity.Name);
    }

    [Fact]
    public async Task GetAsync_WithNonExistentId_ShouldNotBeNull()
    {
        var act = () => _deviceEventService.GetAsync(Guid.Empty);
        await act.ShouldThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task UpdateAsync_WithExistingId_ShouldUpdate()
    {
        const string UpdatedName = "Updated name";
        const string UpdatedDescription = "Updated description";
        var createdEntity = await CreateEntity();
        var updateDto = new CreateOrUpdateDeviceEventDto
        {
            Name = UpdatedName,
        };

        var updatedEntity = await _deviceEventService.UpdateAsync(createdEntity.Id, updateDto);

        updatedEntity.Name.ShouldBe(UpdatedName);
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentId_ShouldThrow()
    {
        var updateDto = new CreateOrUpdateDeviceEventDto
        {
            Name = "updated name",
        };
        var act = () => _deviceEventService.UpdateAsync(Guid.Empty, updateDto);
        await act.ShouldThrowAsync<EntityNotFoundException>();
    }

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
