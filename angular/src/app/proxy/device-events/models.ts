import type { EntityDto } from '@abp/ng.core';

export interface CreateOrUpdateDeviceEventDto {
  name?: string;
  creationDate?: string;
}

export interface DeviceEventDto extends EntityDto<string> {
  name?: string;
  creationTime?: string;
}
