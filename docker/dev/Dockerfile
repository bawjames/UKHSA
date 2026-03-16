FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /UKHSA/App

COPY App/. ./
RUN dotnet restore

ENTRYPOINT ["dotnet", "watch", "run"]
