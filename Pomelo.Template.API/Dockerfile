FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pomelo.Template.API/Pomelo.Template.API.csproj", "Pomelo.Template.API/"]
RUN dotnet restore "Pomelo.Template.API/Pomelo.Template.API.csproj"
COPY . .
WORKDIR "/src/Pomelo.Template.API"
RUN dotnet build "Pomelo.Template.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Pomelo.Template.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pomelo.Template.API.dll"]
