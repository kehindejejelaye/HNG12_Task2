FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HNG12_Task2/HNG12_Task2.csproj", "HNG12_Task2/"]
RUN dotnet restore "HNG12_Task2/HNG12_Task2.csproj"
COPY . .
WORKDIR "/src/HNG12_Task2"
RUN dotnet build "HNG12_Task2.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HNG12_Task2.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HNG12_Task2.dll"]
