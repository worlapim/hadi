# Na https://aka.ms/customizecontainer se dozvíte, jak si přizpůsobit kontejner ladění a jak Visual Studio používá tento dokument Dockerfile k sestavení vašich imagí pro rychlejší ladění.

# V závislosti na operačním systému hostitelských počítačů, které budou vytvářet nebo spouštět kontejnery, může být potřeba změnit image zadanou v příkazu FROM.
# Další informace najdete na https://aka.ms/containercompat.

# Tato fáze se používá při spuštění z VS v rychlém režimu (výchozí pro konfiguraci ladění).
FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app


# Tato fáze slouží k sestavení projektu služby.
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["hadi/hadi.csproj", "hadi/"]
RUN dotnet restore "./hadi/hadi.csproj"
COPY . .
WORKDIR "/src/hadi"
RUN dotnet build "./hadi.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Tato fáze slouží k publikování projektu služby, který se má zkopírovat do konečné fáze.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./hadi.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Tato fáze se používá v produkčním prostředí nebo při spuštění z VS v běžném režimu (výchozí, když se nepoužívá konfigurace ladění).
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hadi.dll"]