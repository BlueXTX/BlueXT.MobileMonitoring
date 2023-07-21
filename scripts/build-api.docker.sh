#!/bin/bash

docker build -f ../aspnet-core/Dockerfile -t bluext/mobile-monitoring ../aspnet-core
docker save bluext/mobile-monitoring > ../bluext-mobile-monitoring.tar