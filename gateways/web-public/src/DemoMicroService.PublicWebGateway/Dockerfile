FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mycompanyname/demomicroservice-base:1.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/gateways/web-public/src/DemoMicroService.PublicWebGateway"
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DemoMicroService.PublicWebGateway.dll"]