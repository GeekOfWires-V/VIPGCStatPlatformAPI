FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/VIPGCStatPlatformAPI.Server.csproj", "Server/"]
COPY ["Client/VIPGCStatPlatformAPI.Client.csproj", "Client/"]
COPY ["Shared/VIPGCStatPlatformAPI.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/VIPGCStatPlatformAPI.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "VIPGCStatPlatformAPI.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VIPGCStatPlatformAPI.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VIPGCStatPlatformAPI.Server.dll"]
