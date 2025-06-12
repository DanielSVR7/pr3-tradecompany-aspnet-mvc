FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["./pr3_tradecompany_aspnet_mvc.csproj", "./"]
RUN dotnet restore "pr3_tradecompany_aspnet_mvc.csproj"

COPY . .
RUN dotnet build "pr3_tradecompany_aspnet_mvc.csproj" -c Release -o /app/build
RUN dotnet publish "pr3_tradecompany_aspnet_mvc.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "pr3_tradecompany_aspnet_mvc.dll"]