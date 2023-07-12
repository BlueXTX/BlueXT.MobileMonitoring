import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
    production: false,
    application: {
        baseUrl,
        name: 'MobileMonitoring',
        logoUrl: '',
    },
    oAuthConfig: {
        issuer: 'https://localhost:44323/',
        redirectUri: baseUrl,
        clientId: 'MobileMonitoring_App',
        responseType: 'code',
        scope: 'offline_access MobileMonitoring',
        requireHttps: true,
    },
    apis: {
        default: {
            url: 'https://localhost:44391',
            rootNamespace: 'BlueXT.MobileMonitoring',
        },
    },
} as Environment;
