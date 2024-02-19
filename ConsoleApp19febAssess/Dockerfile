#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsoleApp19febAssess/ConsoleApp19febAssess.csproj", "ConsoleApp19febAssess/"]
RUN dotnet restore "./ConsoleApp19febAssess/./ConsoleApp19febAssess.csproj"
COPY . .
WORKDIR "/src/ConsoleApp19febAssess"
RUN dotnet build "./ConsoleApp19febAssess.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConsoleApp19febAssess.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleApp19febAssess.dll"]