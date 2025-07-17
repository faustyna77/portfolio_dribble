# Użyj oficjalnego obrazu .NET SDK do budowania
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Skopiuj pliki i przywróć zależności
COPY . ./
RUN dotnet restore

# Opublikuj aplikację
RUN dotnet publish -c Release -o out

# Użyj obrazu runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Uruchom aplikację
ENTRYPOINT ["dotnet", "PortfolioApp.dll"]
