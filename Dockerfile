# Etap 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./

# Przywrócenie zależności
RUN dotnet restore portfolioApp.csproj

# Publikacja aplikacji
RUN dotnet publish portfolioApp.csproj -c Release -o /app/out

# Etap 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

# Punkt wejścia aplikacji
ENTRYPOINT ["dotnet", "portfolioApp.dll"]
