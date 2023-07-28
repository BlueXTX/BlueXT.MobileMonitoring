import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
    production: true,
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
            url: 'http://localhost:8080',
            rootNamespace: 'BlueXT.MobileMonitoring',
        },
    },
} as Environment;
