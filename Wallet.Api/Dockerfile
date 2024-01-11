# How to run? 
# 1. 
#       docker build .  -t wallet.api --no-cache 
# 2. 
#       docker run --name Wallet.Api -p 127.0.0.1:7000:80 wallet.api
# API Url: http://localhost:7000


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
RUN apt-get update && apt-get install -y iputils-ping
WORKDIR /App
COPY --from=build-env /App/out .
ENV ConnectionStrings__DefaultConnection="Server=host.docker.internal;Database=Wallet;User=root;Password=WalletPass;"
ENTRYPOINT ["dotnet", "Wallet.Api.dll"]