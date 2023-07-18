import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeviceEventsRoutingModule } from './device-events-routing.module';
import { DeviceEventsComponent } from './device-events.component';


@NgModule({
  declarations: [
    DeviceEventsComponent
  ],
  imports: [
    CommonModule,
    DeviceEventsRoutingModule
  ]
})
export class DeviceEventsModule { }
