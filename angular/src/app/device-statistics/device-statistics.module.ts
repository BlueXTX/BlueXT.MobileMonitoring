import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeviceStatisticsRoutingModule } from './device-statistics-routing.module';
import { DeviceStatisticsComponent } from './device-statistics.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [DeviceStatisticsComponent],
    imports: [CommonModule, DeviceStatisticsRoutingModule, SharedModule],
})
export class DeviceStatisticsModule {}
