using FluentValidation;

namespace BlueXT.MobileMonitoring.DeviceStatistics.Validators;

public class CreateUpdateDeviceStatisticDtoValidator : AbstractValidator<CreateUpdateDeviceStatisticDto>
{
    public CreateUpdateDeviceStatisticDtoValidator()
    {
        RuleFor(x => x.DeviceId).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.OperatingSystem).NotEmpty();
        RuleFor(x => x.AppVersion).NotEmpty();
    }
}
