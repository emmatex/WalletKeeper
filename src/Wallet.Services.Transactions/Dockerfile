FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Wallet.Services.Transactions/Wallet.Services.Transactions.csproj", "Wallet.Services.Transactions/"]
RUN dotnet restore "Wallet.Services.Transactions/Wallet.Services.Transactions.csproj"
COPY . .
WORKDIR "/src/Wallet.Services.Transactions"
RUN dotnet build "Wallet.Services.Transactions.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Wallet.Services.Transactions.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Wallet.Services.Transactions.dll"]
