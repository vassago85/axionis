# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY AxionisPos.Api.csproj .
RUN dotnet restore AxionisPos.Api.csproj
COPY . .
RUN dotnet publish AxionisPos.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
# SQLite + PDFs. Official image runs as non-root user app (APP_UID, usually 1654).
# Bind-mounting /opt/axionis:/app/data: chown that host dir to the same UID so the process can write.
RUN mkdir -p /app/data/pdfs \
    && chown -R $APP_UID:$APP_UID /app/data \
    && chmod -R u=rwx,g=rx,o= /app/data
COPY --chown=$APP_UID:$APP_UID --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER $APP_UID
ENTRYPOINT ["dotnet", "AxionisPos.Api.dll"]
