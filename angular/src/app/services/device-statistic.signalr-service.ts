import { HubConnectionBuilder } from '@microsoft/signalr';
import { DeviceStatisticDto } from '@proxy/device-statistics';
import { Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class DeviceStatisticSignalRService {
    public readonly deviceStatistic = new Subject<DeviceStatisticDto>();
    private readonly connection = new HubConnectionBuilder()
        .withUrl(`${environment.apis.default.url}/signalr-hubs/device-statistic`)
        .build();

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
