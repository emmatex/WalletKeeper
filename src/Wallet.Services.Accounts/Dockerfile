FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Wallet.Services.Accounts/Wallet.Services.Accounts.csproj", "Wallet.Services.Accounts/"]
COPY ["Wallet.Services.Common/Wallet.Services.Common.csproj", "Wallet.Services.Common/"]
COPY ["Wallet.Common/Wallet.Common.csproj", "Wallet.Common/"]
RUN dotnet restore "Wallet.Services.Accounts/Wallet.Services.Accounts.csproj"
COPY . .
WORKDIR "/src/Wallet.Services.Accounts"
RUN dotnet build "Wallet.Services.Accounts.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Wallet.Services.Accounts.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Wallet.Services.Accounts.dll"]
