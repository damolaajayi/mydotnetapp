# Use the official .NET 8.0 runtime image as a base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET 8.0 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["MyDotNetApp.API/MyDotNetApp.API.csproj", "MyDotNetApp.API/"]
COPY ["MyDotNetApp.Application/MyDotNetApp.Application.csproj", "MyDotNetApp.Application/"]
COPY ["MyDotNetApp.Domain/MyDotNetApp.Domain.csproj", "MyDotNetApp.Domain/"]
COPY ["MyDotNetApp.Infrastructure/MyDotNetApp.Infrastructure.csproj", "MyDotNetApp.Infrastructure/"]



# Restore dependencies
RUN dotnet restore MyDotNetApp.API/MyDotNetApp.API.csproj

# Copy the rest of the source code
COPY . .

# Build the project
WORKDIR "/src/MyDotNetApp.API"
RUN dotnet build "MyDotNetApp.API.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "MyDotNetApp.API.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point
ENTRYPOINT ["dotnet", "MyDotNetApp.API.dll"]
