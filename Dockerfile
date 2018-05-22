FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /app

# Copy the project file
COPY *.sln ./
COPY RefuelService.App/*.csproj ./RefuelService.App/
COPY RefuelService.Core/*.csproj ./RefuelService.Core/
COPY RefuelService.Infrastructure/*.csproj ./RefuelService.Infrastructure/


# Restore the packages
RUN dotnet restore

# Copy everything else
COPY . ./
WORKDIR /app/RefuelService.App

FROM build AS publish
# Build the release
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM microsoft/aspnetcore:2.0 AS runtime
WORKDIR /app

# Copy the output from the build env
COPY --from=publish /app/RefuelService.App/out ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "RefuelService.App.dll" ]