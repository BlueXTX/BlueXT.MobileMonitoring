import type { EntityDto } from '@abp/ng.core';

export interface CreateOrUpdateDeviceEventDto {
  name?: string;
  deviceId?: string;
  creationDate?: string;
}

export interface DeviceEventDto extends EntityDto<string> {
  name?: string;
  creationDate?: string;
}
