FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY . ./
RUN dotnet publish src/Presentation/Micro.Auth.Administration.API/Micro.Auth.Administration.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY ./aspnetapp.pfx /https/
ENTRYPOINT ["dotnet", "Micro.Auth.Administration.API.dll"]