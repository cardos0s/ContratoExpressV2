FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ContratoExpress.sln .
COPY src/ContratoExpress.Server/ContratoExpress.Server.csproj src/ContratoExpress.Server/
COPY src/ContratoExpress.Client/ContratoExpress.Client.csproj src/ContratoExpress.Client/
RUN dotnet restore

COPY . .
RUN dotnet publish src/ContratoExpress.Server/ContratoExpress.Server.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ContratoExpress.Server.dll"]
