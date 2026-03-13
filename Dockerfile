FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ./src/UKHSA.csproj .
RUN dotnet restore

COPY . .

RUN dotnet clean
ENTRYPOINT ["dotnet", "watch", "run"]
