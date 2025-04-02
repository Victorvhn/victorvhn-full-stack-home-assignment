FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__DefaultConnection="Host=ep-shrill-snowflake-acuntad8-pooler.sa-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Ct5m9raRklZQ;SSL Mode=Require;Trust Server Certificate=true"
ENV Authentication__Secret=victorvhn-prod-super-secret

COPY ["Directory.Build.props", "."]
COPY ["Directory.Packages.props", "."]

COPY ["src/FamilyTree.Api/FamilyTree.Api.csproj", "FamilyTree.Api/"]
COPY ["src/FamilyTree.Application/FamilyTree.Application.csproj", "FamilyTree.Application/"]
COPY ["src/FamilyTree.Domain/FamilyTree.Domain.csproj", "FamilyTree.Domain/"]
COPY ["src/FamilyTree.Infrastructure/FamilyTree.Infrastructure.csproj", "FamilyTree.Infrastructure/"]

RUN dotnet restore "FamilyTree.Api/FamilyTree.Api.csproj"

COPY . .

WORKDIR "src/FamilyTree.Api"

RUN dotnet build "FamilyTree.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FamilyTree.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "FamilyTree.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet FamilyTree.Api.dll


#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#
#ARG BUILD_CONFIGURATION=Release
#
#WORKDIR /src
#
#COPY ["Directory.Build.props", "."]
#COPY ["Directory.Packages.props", "."]
#
#COPY ["src/FamilyTree.Api/FamilyTree.Api.csproj", "FamilyTree.Api/"]
#COPY ["src/FamilyTree.Application/FamilyTree.Application.csproj", "FamilyTree.Application/"]
#COPY ["src/FamilyTree.Domain/FamilyTree.Domain.csproj", "FamilyTree.Domain/"]
#COPY ["src/FamilyTree.Infrastructure/FamilyTree.Infrastructure.csproj", "FamilyTree.Infrastructure/"]
#
#RUN dotnet restore "FamilyTree.Api/FamilyTree.Api.csproj"
#
#COPY . .
#
#WORKDIR "/src/FamilyTree.Api"
#
#RUN dotnet build "FamilyTree.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "FamilyTree.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "FamilyTree.Api.dll"]
