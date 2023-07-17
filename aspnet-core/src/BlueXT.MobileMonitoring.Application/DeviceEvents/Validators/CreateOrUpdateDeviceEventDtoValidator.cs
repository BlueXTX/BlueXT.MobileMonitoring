﻿using FluentValidation;

namespace BlueXT.MobileMonitoring.DeviceEvents.Validators;

/// <summary>
/// Валидатор DTO <see cref="CreateOrUpdateDeviceEventDto"/>.
/// </summary>
public class CreateOrUpdateDeviceEventDtoValidator : AbstractValidator<CreateOrUpdateDeviceEventDto>
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public CreateOrUpdateDeviceEventDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(maximumLength: 128);
        RuleFor(x => x.Description).MaximumLength(maximumLength: 512);
    }
}
