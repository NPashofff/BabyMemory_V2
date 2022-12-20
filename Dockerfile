FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/BabyMemory_V2.Web.Host/BabyMemory_V2.Web.Host.csproj", "src/BabyMemory_V2.Web.Host/"]
COPY ["src/BabyMemory_V2.Web.Core/BabyMemory_V2.Web.Core.csproj", "src/BabyMemory_V2.Web.Core/"]
COPY ["src/BabyMemory_V2.Application/BabyMemory_V2.Application.csproj", "src/BabyMemory_V2.Application/"]
COPY ["src/BabyMemory_V2.Core/BabyMemory_V2.Core.csproj", "src/BabyMemory_V2.Core/"]
COPY ["src/BabyMemory_V2.EntityFrameworkCore/BabyMemory_V2.EntityFrameworkCore.csproj", "src/BabyMemory_V2.EntityFrameworkCore/"]
WORKDIR "/src/src/BabyMemory_V2.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BabyMemory_V2.Web.Host", "src/BabyMemory_V2.Web.Host"]
COPY ["src/BabyMemory_V2.Web.Core", "src/BabyMemory_V2.Web.Core"]
COPY ["src/BabyMemory_V2.Application", "src/BabyMemory_V2.Application"]
COPY ["src/BabyMemory_V2.Core", "src/BabyMemory_V2.Core"]
COPY ["src/BabyMemory_V2.EntityFrameworkCore", "src/BabyMemory_V2.EntityFrameworkCore"]
WORKDIR "/src/src/BabyMemory_V2.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BabyMemory_V2.Web.Host.dll"]
