import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeviceEventDto, DeviceEventService } from '@proxy/device-events';
import { DeviceStatisticDto, DeviceStatisticService } from '@proxy/device-statistics';
import { BehaviorSubject, forkJoin, interval, Observable, Subject, Subscription, switchMap, takeUntil } from 'rxjs';

@Component({
    selector: 'app-device-events',
    templateUrl: './device-events.component.html',
    styleUrls: ['./device-events.component.scss'],
})
export class DeviceEventsComponent implements OnInit, OnDestroy {
    deviceId?: string = '';
    deviceStatistic: DeviceStatisticDto = {};
    deviceEvents: DeviceEventDto[] = [];
    isLoading = true;
    autoUpdate = new BehaviorSubject<boolean>(true);
    private intervalSubscription: Subscription;
    private readonly onDestroy$ = new Subject<boolean>();

    constructor(
        private readonly activeRoute: ActivatedRoute,
        private readonly deviceStatisticService: DeviceStatisticService,
        private readonly deviceEventsService: DeviceEventService,
    ) {}

    ngOnInit(): void {
        this.loadDeviceIdFromQueryParams();
        this.loadData();
        this.subscribeToCheckboxUpdate();
    }

    onValueChange(input: HTMLInputElement): void {
        this.autoUpdate.next(input.checked);
    }

    ngOnDestroy(): void {
        this.onDestroy$.next(true);
        this.onDestroy$.complete();
        this.autoUpdate.complete();
    }

    private subscribeToCheckboxUpdate(): void {
        this.autoUpdate.pipe(takeUntil(this.onDestroy$)).subscribe((value: boolean) => {
            if (value === true) {
                this.subscribeToAutoUpdates();
            } else {
                this.intervalSubscription.unsubscribe();
            }
        });
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
        forkJoin({
            deviceStatistic: this.getDeviceStatistic(),
            deviceEvents: this.getDeviceEvents(),
        })
            .pipe(takeUntil(this.onDestroy$))
            .subscribe(response => {
                this.deviceStatistic = response.deviceStatistic;
                this.deviceEvents = response.deviceEvents;
                this.isLoading = false;
            });
    }

    private subscribeToAutoUpdates(): void {
        this.intervalSubscription = interval(30000)
            .pipe(switchMap(() => this.getDeviceEvents()))
            .pipe(takeUntil(this.onDestroy$))
            .subscribe(response => {
                this.deviceEvents = response;
            });
    }
}
