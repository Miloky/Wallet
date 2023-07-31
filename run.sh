echo "Starting docker...";
docker-compose up -d;
echo "Docker running...";
cd ./Wallet.Api
dotnet ef database update --project ./Wallet.Api.csproj
cd ..



docker container exec -it wallet-db-1 bash
mysql -u root -p