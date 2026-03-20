FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /UKHSA/App

COPY App/. ./
RUN dotnet restore
RUN dotnet tool restore

ENTRYPOINT ["dotnet", "ef", "database", "update"]
