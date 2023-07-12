import type { CreateOrUpdateDeviceStatisticDto, DeviceStatisticDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DeviceStatisticService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateDeviceStatisticDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceStatisticDto>({
      method: 'POST',
      url: '/api/app/device-statistic',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/device-statistic/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceStatisticDto>({
      method: 'GET',
      url: `/api/app/device-statistic/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DeviceStatisticDto>>({
      method: 'GET',
      url: '/api/app/device-statistic',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrUpdateDeviceStatisticDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DeviceStatisticDto>({
      method: 'PUT',
      url: `/api/app/device-statistic/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
