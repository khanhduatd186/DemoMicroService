FROM mycompanyname/demomicroservice-base:1.0 AS build
WORKDIR /src

COPY . .
RUN dotnet publish -c Release -o /app 

FROM nginx:alpine AS final
COPY apps/blazor/src/DemoMicroService.Blazor/nginx.conf  /etc/nginx/conf.d/default.conf
WORKDIR /usr/share/nginx/html
COPY --from=build /app/wwwroot .