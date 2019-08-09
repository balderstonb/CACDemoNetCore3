FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CACDemoNetCore3/CACDemoNetCore3.csproj", "CACDemoNetCore3/"]
RUN dotnet restore "CACDemoNetCore3/CACDemoNetCore3.csproj"
COPY . .
WORKDIR "/src/CACDemoNetCore3"
RUN dotnet build "CACDemoNetCore3.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CACDemoNetCore3.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CACDemoNetCore3.dll"]