FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["School.Api/School.Api.csproj", "School.Api/"]
RUN dotnet restore "School.Api/School.Api.csproj"
COPY . .
WORKDIR "/src/School.Api"
RUN dotnet build "School.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "School.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School.Api.dll"]
