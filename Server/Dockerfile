# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Expose port 80 for the application
EXPOSE 80

# Copy the solution file and all project files
COPY Server.sln .
COPY api/api.csproj api/api.csproj
COPY Contracts/Contracts.csproj Contracts/Contracts.csproj
COPY E-Learning.Presentation/E-Learning.Presentation.csproj  E-Learning.Presentation/E-Learning.Presentation.csproj
COPY Entities/Entities.csproj Entities/Entities.csproj
COPY Repository/Repository.csproj Repository/Repository.csproj
COPY Service/Service.csproj Service/Service.csproj
COPY Shared/Shared.csproj Shared/Shared.csproj

# Restore dependencies
RUN dotnet restore

# Copy all source code
COPY . .

# Publish the application to the /out directory in Release mode
WORKDIR /app/api
RUN dotnet publish -c Release -o /app/src/out

# Use the .NET Runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output from the build stage
COPY --from=build /app/src/out .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "api.dll"]
