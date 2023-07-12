import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { DeviceStatisticDto, DeviceStatisticService } from '@proxy/device-statistics';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-device-statistics',
    templateUrl: './device-statistics.component.html',
    styleUrls: ['./device-statistics.component.scss'],
    providers: [ListService],
})
export class DeviceStatisticsComponent implements OnInit {
    deviceStatistics = { items: [], totalCount: 0 } as PagedResultDto<DeviceStatisticDto>;

    constructor(
        public readonly list: ListService,
        private deviceStatisticService: DeviceStatisticService,
    ) {}

    ngOnInit(): void {
        const streamCreator = (query): Observable<PagedResultDto<DeviceStatisticDto>> =>
            this.deviceStatisticService.getList(query);

        this.list.hookToQuery(streamCreator).subscribe(response => {
            this.deviceStatistics = response;
        });
    }
}
