import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeviceStatisticsRoutingModule } from './device-statistics-routing.module';
import { DeviceStatisticsComponent } from './device-statistics.component';

@NgModule({
    declarations: [DeviceStatisticsComponent],
    imports: [CommonModule, DeviceStatisticsRoutingModule],
})
export class DeviceStatisticsModule {}
