import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeviceEventsRoutingModule } from './device-events-routing.module';
import { DeviceEventsComponent } from './device-events.component';
import { BaseThemeSharedModule } from '@abp/ng.theme.shared';
import { LocalizationModule } from '@abp/ng.core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
    declarations: [DeviceEventsComponent],
    imports: [CommonModule, DeviceEventsRoutingModule, BaseThemeSharedModule, LocalizationModule, NgxDatatableModule],
})
export class DeviceEventsModule {}
