import { HubConnectionBuilder } from '@microsoft/signalr';
import { DeviceStatisticDto } from '@proxy/device-statistics';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class DeviceStatisticSignalRService {
    private readonly connection = new HubConnectionBuilder()
        .withUrl(`${environment.apis.default.url}/signalr-hubs/device-statistic`)
        .build();
    public readonly deviceStatistic = new Subject<DeviceStatisticDto>();

    constructor() {
        this.openConnection();
        this.subscribeToUpdates();
    }

    private openConnection(): void {
        this.connection.start();
    }

    private subscribeToUpdates(): void {
        this.connection.on('ReceiveUpdate', (dto: DeviceStatisticDto) => {
            this.deviceStatistic.next(dto);
        });
    }
}
