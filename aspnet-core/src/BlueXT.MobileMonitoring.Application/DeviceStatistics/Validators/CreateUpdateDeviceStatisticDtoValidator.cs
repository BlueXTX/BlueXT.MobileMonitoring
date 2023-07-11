using FluentValidation;

namespace BlueXT.MobileMonitoring.DeviceStatistics.Validators;

/// <summary>
/// Валидатор для сущности <see cref="CreateOrUpdateDeviceStatisticDto"/>.
/// </summary>
public class CreateUpdateDeviceStatisticDtoValidator : AbstractValidator<CreateOrUpdateDeviceStatisticDto>
{
    /// <summary>
    /// Набор правил.
    /// </summary>
    public CreateUpdateDeviceStatisticDtoValidator()
    {
        RuleFor(x => x.DeviceId).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.OperatingSystem).NotEmpty();
        RuleFor(x => x.AppVersion).NotEmpty();
    }
}
