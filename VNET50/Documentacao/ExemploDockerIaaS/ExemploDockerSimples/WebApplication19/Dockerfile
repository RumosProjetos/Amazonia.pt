#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["WebApplication19/WebApplication19.csproj", "WebApplication19/"]
RUN dotnet restore "WebApplication19/WebApplication19.csproj"
COPY . .
WORKDIR "/src/WebApplication19"
RUN dotnet build "WebApplication19.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication19.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication19.dll"]