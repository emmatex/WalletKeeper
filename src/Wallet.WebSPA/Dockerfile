FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Wallet.WebSPA/Wallet.WebSPA.csproj", "Wallet.WebSPA/"]
RUN dotnet restore "Wallet.WebSPA/Wallet.WebSPA.csproj"
COPY . .
WORKDIR "/src/Wallet.WebSPA"
RUN dotnet build "Wallet.WebSPA.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Wallet.WebSPA.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Wallet.WebSPA.dll"]
