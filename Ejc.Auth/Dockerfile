FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Ejc.Auth/Ejc.Auth.csproj", "Ejc.Auth/"]
RUN dotnet restore "Ejc.Auth/Ejc.Auth.csproj"
COPY . .
WORKDIR "/src/Ejc.Auth"
RUN dotnet build "Ejc.Auth.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ejc.Auth.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ejc.Auth.dll"]