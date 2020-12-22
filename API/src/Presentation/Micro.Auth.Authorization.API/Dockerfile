#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Presentation/Micro.Auth.Authorization.API/Micro.Auth.Authorization.API.csproj", "src/Presentation/Micro.Auth.Authorization.API/"]
RUN dotnet restore "src/Presentation/Micro.Auth.Authorization.API/Micro.Auth.Authorization.API.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Micro.Auth.Authorization.API"
RUN dotnet build "Micro.Auth.Authorization.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Auth.Authorization.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Auth.Authorization.API.dll"]