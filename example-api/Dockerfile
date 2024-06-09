FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /App

# Copy everything
COPY ./example-api/ ./example-api/

WORKDIR /App/example-api
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

EXPOSE 8080 

COPY --from=build-env /App/example-api/out .

ENTRYPOINT ["dotnet", "example-api.dll"]