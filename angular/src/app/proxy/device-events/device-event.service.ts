import type { CreateOrUpdateDeviceEventDto, DeviceEventDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DeviceEventService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateDeviceEventDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceEventDto>({
      method: 'POST',
      url: '/api/app/device-event',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/device-event/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceEventDto>({
      method: 'GET',
      url: `/api/app/device-event/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DeviceEventDto>>({
      method: 'GET',
      url: '/api/app/device-event',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListByDeviceId = (deviceId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceEventDto[]>({
      method: 'GET',
      url: `/api/app/device-event/by-device-id/${deviceId}`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrUpdateDeviceEventDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceEventDto>({
      method: 'PUT',
      url: `/api/app/device-event/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
