import type { CreateOrUpdateDeviceEventDto } from '../device-events/models';
import type { EntityDto } from '@abp/ng.core';

export interface CreateOrUpdateDeviceStatisticDto {
  deviceId?: string;
  username?: string;
  operatingSystem?: string;
  appVersion?: string;
  deviceEvents: CreateOrUpdateDeviceEventDto[];
}

export interface DeviceStatisticDto extends EntityDto<string> {
  deviceId?: string;
  username?: string;
  operatingSystem?: string;
  appVersion?: string;
}
