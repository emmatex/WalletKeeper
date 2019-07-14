FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Wallet.Services.Identity/Wallet.Services.Identity.csproj", "Wallet.Services.Identity/"]
COPY ["Wallet.Common/Wallet.Common.csproj", "Wallet.Common/"]
COPY ["Wallet.Services.Common/Wallet.Services.Common.csproj", "Wallet.Services.Common/"]
RUN dotnet restore "Wallet.Services.Identity/Wallet.Services.Identity.csproj"
COPY . .
WORKDIR "/src/Wallet.Services.Identity"
RUN dotnet build "Wallet.Services.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Wallet.Services.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Wallet.Services.Identity.dll"]