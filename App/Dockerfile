FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /App

COPY . ./
RUN dotnet restore

RUN dotnet clean
ENTRYPOINT ["dotnet", "watch", "run", "--no-launch-profile"]
