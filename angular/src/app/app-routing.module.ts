import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    },
    {
        path: 'account',
        loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
    },
    {
        path: 'identity',
        loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
    },
    {
        path: 'tenant-management',
        loadChildren: () => import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
    },
    {
        path: 'setting-management',
        loadChildren: () => import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
    },
    {
        path: 'device-statistics',
        loadChildren: () => import('./device-statistics/device-statistics.module').then(m => m.DeviceStatisticsModule),
    },
    {
        path: 'device-events',
        loadChildren: () => import('./device-events/device-events.module').then(m => m.DeviceEventsModule),
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes, {})],
    exports: [RouterModule],
})
export class AppRoutingModule {}
