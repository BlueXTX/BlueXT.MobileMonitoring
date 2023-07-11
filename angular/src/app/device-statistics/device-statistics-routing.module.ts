import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeviceStatisticsComponent } from './device-statistics.component';

const routes: Routes = [{ path: '', component: DeviceStatisticsComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DeviceStatisticsRoutingModule {}
