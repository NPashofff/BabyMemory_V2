#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/BabyMemory_V2.Web.Mvc/BabyMemory_V2.Web.Mvc.csproj", "src/BabyMemory_V2.Web.Mvc/"]
COPY ["src/BabyMemory_V2.Web.Core/BabyMemory_V2.Web.Core.csproj", "src/BabyMemory_V2.Web.Core/"]
COPY ["src/BabyMemory_V2.Application/BabyMemory_V2.Application.csproj", "src/BabyMemory_V2.Application/"]
COPY ["src/BabyMemory_V2.Core/BabyMemory_V2.Core.csproj", "src/BabyMemory_V2.Core/"]
COPY ["src/BabyMemory_V2.EntityFrameworkCore/BabyMemory_V2.EntityFrameworkCore.csproj", "src/BabyMemory_V2.EntityFrameworkCore/"]
RUN dotnet restore "src/BabyMemory_V2.Web.Mvc/BabyMemory_V2.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/BabyMemory_V2.Web.Mvc"
RUN dotnet build "BabyMemory_V2.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BabyMemory_V2.Web.Mvc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BabyMemory_V2.Web.Mvc.dll"]