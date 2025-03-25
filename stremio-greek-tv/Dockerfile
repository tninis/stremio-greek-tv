#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY [".", "stremio-greek-tv/"]
RUN dotnet restore "stremio-greek-tv/stremio-greek-tv.csproj"
COPY . .
WORKDIR "/src/stremio-greek-tv"
RUN dotnet build "stremio-greek-tv.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "stremio-greek-tv.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://0.0.0.0:8080 dotnet stremio-greek-tv.dll