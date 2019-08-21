# REDHAT Docker file
FROM nexus.shtormtech.ru:5000/dotnet/dotnet-22-rhel7 AS build-env
WORKDIR /app

# switch to root
USER 0
RUN mkdir obj

# Copy csproj and restore as distinct layers
COPY . ./

# REDHAT specific - we need to enable dotnet CLI
#RUN scl enable rh-dotnet22 -- dotnet restore

# restore nuget package
RUN scl enable rh-dotnet22 -- dotnet restore -s http://nexus.shtormtech.ru/repository/nuget-group/ --disable-parallel

# run unit tets - build will fail if tests fail
# RUN scl enable rh-dotnet22 -- dotnet test Tests.EffortAPIService

# build
RUN scl enable rh-dotnet22 -- dotnet publish EffortAPIService/EffortAPIService.csproj -c Release -o out --no-restore

# Build runtime image
FROM nexus.shtormtech.ru:5000/dotnet/dotnet-22-runtime-rhel7
EXPOSE 8080
WORKDIR /app
COPY --from=build-env /app/EffortAPIService/out .
ENTRYPOINT ["sh","-c","scl enable rh-dotnet22 -- dotnet EffortAPIService.dll"]