import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeviceEventsComponent } from './device-events.component';

const routes: Routes = [{ path: '', component: DeviceEventsComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DeviceEventsRoutingModule {}
