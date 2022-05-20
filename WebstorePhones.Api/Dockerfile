#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebstorePhones.Api/WebstorePhones.Api.csproj", "WebstorePhones.Api/"]
COPY ["WebstorePhones.Domain/WebstorePhones.Domain.csproj", "WebstorePhones.Domain/"]
COPY ["WebstorePhones.Business/WebstorePhones.Business.csproj", "WebstorePhones.Business/"]
RUN dotnet restore "WebstorePhones.Api/WebstorePhones.Api.csproj"
COPY . .
WORKDIR "/src/WebstorePhones.Api"
RUN dotnet build "WebstorePhones.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebstorePhones.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebstorePhones.Api.dll"]
