#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8090


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API_Masivian/API_Masivian.csproj", "API_Masivian/"]
RUN dotnet restore "API_Masivian/API_Masivian.csproj"
COPY . .
WORKDIR "/src/API_Masivian"
RUN dotnet build "API_Masivian.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_Masivian.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+8090
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Masivian.dll"]