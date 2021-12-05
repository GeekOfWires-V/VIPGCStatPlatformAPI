FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VIPGCStatPlatformAPI/VIPGCStatPlatformAPI.csproj", "VIPGCStatPlatformAPI/"]
RUN dotnet restore "VIPGCStatPlatformAPI/VIPGCStatPlatformAPI.csproj"
COPY . .
WORKDIR "/src/VIPGCStatPlatformAPI"
RUN dotnet build "VIPGCStatPlatformAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VIPGCStatPlatformAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VIPGCStatPlatformAPI.dll"]
