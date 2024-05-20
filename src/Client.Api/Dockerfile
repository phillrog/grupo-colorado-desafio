#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5005
EXPOSE 5006
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Client.Api/Client.Api.csproj", "src/Client.Api/"]
COPY ["Client.Application/Client.Application.csproj", "src/Client.Application/"]
COPY ["Client.Domain/Client.Domain.csproj", "src/Client.Domain/"]
COPY ["Client.Infrastructure/Client.Infrastructure.csproj", "src/Client.Infrastructure/"]
RUN dotnet restore "./src/Client.Api/Client.Api.csproj"
COPY . .

RUN apt-get update && apt-get install -y iputils-ping

WORKDIR "/src/Client.Api"
RUN dotnet build "./Client.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Client.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.Api.dll"]