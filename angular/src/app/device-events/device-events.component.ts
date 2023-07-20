import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeviceEventDto, DeviceEventService } from '@proxy/device-events';
import { DeviceStatisticDto, DeviceStatisticService } from '@proxy/device-statistics';
import { forkJoin, Observable } from 'rxjs';

@Component({
    selector: 'app-device-events',
    templateUrl: './device-events.component.html',
    styleUrls: ['./device-events.component.scss'],
})
export class DeviceEventsComponent implements OnInit {
    deviceId?: string = '';
    deviceStatistic: DeviceStatisticDto = {};
    deviceEvents: DeviceEventDto[] = [];
    isLoading = true;

    constructor(
        private readonly activeRoute: ActivatedRoute,
        private readonly deviceStatisticService: DeviceStatisticService,
        private readonly deviceEventsService: DeviceEventService,
    ) {}

    ngOnInit(): void {
        this.loadDeviceIdFromQueryParams();
        this.loadData();
    }

    private getDeviceStatistic(): Observable<DeviceStatisticDto> {
        return this.deviceStatisticService.getByDeviceId(this.deviceId);
    }

    private getDeviceEvents(): Observable<DeviceEventDto[]> {
        return this.deviceEventsService.getListByDeviceId(this.deviceId);
    }

    private loadDeviceIdFromQueryParams(): void {
        this.deviceId = this.activeRoute.snapshot.queryParams['deviceId'];
    }

    private loadData(): void {
        forkJoin({ deviceStatistic: this.getDeviceStatistic(), deviceEvents: this.getDeviceEvents() }).subscribe(
            response => {
                this.deviceStatistic = response.deviceStatistic;
                this.deviceEvents = response.deviceEvents;
                this.isLoading = false;
            },
        );
    }
}
