FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VIPGCStatPlatform.API/VIPGCStatPlatform.API.csproj", "VIPGCStatPlatform.API/"]
COPY ["VIPGCStatPlatform.Shared/VIPGCStatPlatform.Shared.csproj", "VIPGCStatPlatform.Shared/"]
COPY ["VIPGCStatPlatform/VIPGCStatPlatform.csproj", "VIPGCStatPlatform/"]
RUN dotnet restore "VIPGCStatPlatform.API/VIPGCStatPlatform.API.csproj"
COPY . .
WORKDIR "/src/VIPGCStatPlatform.API"
RUN dotnet build "VIPGCStatPlatform.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VIPGCStatPlatform.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VIPGCStatPlatform.API.dll"]
