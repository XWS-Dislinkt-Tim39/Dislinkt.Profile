#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Dislinkt.Profile/Dislinkt.Profile.WebApi.csproj", "Dislinkt.Profile/"]
COPY ["Dislinkt.Profile.Core/Dislinkt.Profile.Core.csproj", "Dislinkt.Profile.Core/"]
COPY ["Dislinkt.Profile.Domain/Dislinkt.Profile.Domain.csproj", "Dislinkt.Profile.Domain/"]
COPY ["Dislinkt.Profile.Application/Dislinkt.Profile.csproj", "Dislinkt.Profile.Application/"]
COPY ["Dislinkt.Profile.App/Dislinkt.Profile.App.csproj", "Dislinkt.Profile.App/"]
COPY ["Dislinkt.Profile.Persistance.MongoDB/Dislinkt.Profile.Persistance.MongoDB.csproj", "Dislinkt.Profile.Persistance.MongoDB/"]
COPY ["Dislinkt.Profile.RabbitMQ/Dislinkt.Profile.RabbitMQ.csproj", "Dislinkt.Profile.RabbitMQ/"]
RUN dotnet restore "Dislinkt.Profile/Dislinkt.Profile.WebApi.csproj"
COPY . .
WORKDIR "/src/Dislinkt.Profile"
RUN dotnet build "Dislinkt.Profile.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dislinkt.Profile.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dislinkt.Profile.WebApi.dll"]