FROM node:20-alpine3.17 as build
WORKDIR /usr/src/app
COPY package.json yarn.lock ./
RUN yarn
COPY . .
RUN yarn build:prod

FROM nginx:1.25.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/MobileMonitoring /usr/share/nginx/html