FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Udv.Web/Udv.Web.csproj", "Udv.Web/"]
COPY ["Udv.Core/Udv.Core.csproj", "Udv.Core/"]
COPY ["Udv.Infrastructure/Udv.Infrastructure.csproj", "Udv.Infrastructure/"]
RUN dotnet restore "Udv.Web/Udv.Web.csproj"
COPY . .
WORKDIR "/src/Udv.Web"
RUN dotnet build "Udv.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Udv.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Udv.Web.dll"]
