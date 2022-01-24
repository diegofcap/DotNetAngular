#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DotNetAngular.Api/DotNetAngular.Api.csproj", "src/DotNetAngular.Api/"]
COPY ["src/DotNetAngular.Api.Framework/DotNetAngular.Api.Framework.csproj", "src/DotNetAngular.Api.Framework/"]
COPY ["src/DotNetAngular.Services/DotNetAngular.Services.csproj", "src/DotNetAngular.Services/"]
COPY ["src/DotNetAngular.Core/DotNetAngular.Core.csproj", "src/DotNetAngular.Core/"]
COPY ["src/DotNetAngular.Data/DotNetAngular.Data.csproj", "src/DotNetAngular.Data/"]
RUN dotnet restore "src/DotNetAngular.Api/DotNetAngular.Api.csproj"
COPY . .
WORKDIR "/src/src/DotNetAngular.Api"
RUN dotnet build "DotNetAngular.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetAngular.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetAngular.Api.dll"]
