import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeviceEventDto, DeviceEventService } from '@proxy/device-events';
import { DeviceStatisticDto, DeviceStatisticService } from '@proxy/device-statistics';

@Component({
    selector: 'app-device-events',
    templateUrl: './device-events.component.html',
    styleUrls: ['./device-events.component.scss'],
})
export class DeviceEventsComponent implements OnInit {
    deviceId?: string = '';
    deviceStatistic: DeviceStatisticDto = {};
    deviceEvents: DeviceEventDto[] = [];

    constructor(
        private readonly activeRoute: ActivatedRoute,
        private readonly deviceStatisticService: DeviceStatisticService,
        private readonly deviceEventsService: DeviceEventService,
    ) {}

    ngOnInit(): void {
        this.deviceId = this.activeRoute.snapshot.queryParams['deviceId'];
        this.deviceStatisticService.getByDeviceId(this.deviceId).subscribe(response => {
            this.deviceStatistic = response;
        });
        this.deviceEventsService.getListByDeviceId(this.deviceId).subscribe(response => {
            this.deviceEvents = response;
        });
    }
}
