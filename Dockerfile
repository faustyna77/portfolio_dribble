# Etap 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Skopiuj całość
COPY . ./

# Przywrócenie zależności (tu poprawna nazwa projektu!)
RUN dotnet restore PortfolioApp.csproj

# Publikacja
RUN dotnet publish PortfolioApp.csproj -c Release -o /app/out

# Etap 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "PortfolioApp.dll"]
