#!/bin/bash

cd ../aspnet-core/src/BlueXT.MobileMonitoring.HttpApi.Host || exit 1
dotnet publish -c Release
