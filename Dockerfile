# Base image chứa ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image với SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish QLSCLAPI/QLSCLAPI.csproj -c Release -o /app/publish

# Final image để chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "QLSCLAPI.dll"]
