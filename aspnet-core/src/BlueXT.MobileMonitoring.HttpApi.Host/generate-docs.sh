#!/bin/bash

mkdir -p docs
curl https://localhost:44391/swagger/v1/swagger.json -o ./docs/specification.json
npx @redocly/cli build-docs ./docs/specification.json -o ./docs/redoc-static.html
