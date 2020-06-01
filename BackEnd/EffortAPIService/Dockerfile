# ubuntu Docker file
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env
WORKDIR /app

# switch to root
USER 0
RUN mkdir obj

# Copy csproj and restore as distinct layers
COPY . ./

# restore nuget package
RUN dotnet restore -s https://api.nuget.org/v3/index.json

# run unit tets - build will fail if tests fail
# RUN dotnet test Tests.EffortAPIService

# build
RUN dotnet publish EffortAPIService/EffortAPIService.csproj -c Release -o /app/out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
EXPOSE 8080
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "EffortAPIService.dll"]