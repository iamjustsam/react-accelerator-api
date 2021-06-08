FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["react-accelerator-api/react-accelerator-api.csproj", "react-accelerator-api/"]
RUN dotnet restore "react-accelerator-api/react-accelerator-api.csproj"
COPY . .
WORKDIR "/src/react-accelerator-api"
RUN dotnet build "react-accelerator-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "react-accelerator-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "react-accelerator-api.dll"]
