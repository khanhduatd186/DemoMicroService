FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mycompanyname/demomicroservice-base:1.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/apps/auth-server/src/DemoMicroService.AuthServer"
RUN dotnet publish -c Release -o /app
RUN dotnet dev-certs https -v -ep /app/openiddict.pfx -p 321d4813-ba41-4619-abda-e8746de43ee4

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DemoMicroService.AuthServer.dll"]