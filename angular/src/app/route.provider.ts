import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
    { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
    return (): void => {
        routesService.add([
            {
                path: '/',
                name: '::Menu:Home',
                iconClass: 'fas fa-home',
                order: 1,
                layout: eLayoutType.application,
            },
            {
                path: '/device-statistics',
                name: '::Menu:DeviceStatistics',
                iconClass: 'fas fa-regular fa-chart-bar',
                order: 2,
                layout: eLayoutType.application,
            },
        ]);
    };
}
