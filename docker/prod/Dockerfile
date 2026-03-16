FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /UKHSA/App

COPY App/. ./
RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /UKHSA/App
COPY --from=build /UKHSA/App/out .
ENTRYPOINT ["dotnet", "UKHSA.dll"]
