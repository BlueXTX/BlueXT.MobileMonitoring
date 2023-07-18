import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { DeviceStatisticDto, DeviceStatisticService } from '@proxy/device-statistics';
import { Observable } from 'rxjs';
import { NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { DeviceEventsComponent } from '../device-events/device-events.component';
import { SelectionType } from '@swimlane/ngx-datatable';

@Component({
    selector: 'app-device-statistics',
    templateUrl: './device-statistics.component.html',
    styleUrls: ['./device-statistics.component.scss'],
    providers: [ListService],
})
export class DeviceStatisticsComponent implements OnInit {
    deviceStatistics = { items: [], totalCount: 0 } as PagedResultDto<DeviceStatisticDto>;
    selectionType = SelectionType.single;
    selected: DeviceStatisticDto[] = [];

    constructor(
        public readonly list: ListService,
        private deviceStatisticService: DeviceStatisticService,
        private offcanvasService: NgbOffcanvas,
    ) {}

    ngOnInit(): void {
        const streamCreator = (query): Observable<PagedResultDto<DeviceStatisticDto>> =>
            this.deviceStatisticService.getList(query);

        this.list.hookToQuery(streamCreator).subscribe(response => {
            this.deviceStatistics = response;
        });
    }

    open($event: any): void {
        this.selected = $event.selected;
        this.offcanvasService
            .open(DeviceEventsComponent, {
                position: 'end',
                panelClass: 'w-50',
                backdropClass: 'opacity-25',
            })
            .dismissed.subscribe(() => {
                this.selected = [];
            });
    }
}
