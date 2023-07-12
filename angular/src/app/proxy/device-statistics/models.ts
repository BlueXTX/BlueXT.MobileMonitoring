
export interface CreateOrUpdateDeviceStatisticDto {
  deviceId?: string;
  username?: string;
  operatingSystem?: string;
  appVersion?: string;
}

export interface DeviceStatisticDto {
  id?: string;
  deviceId?: string;
  username?: string;
  operatingSystem?: string;
  appVersion?: string;
}
