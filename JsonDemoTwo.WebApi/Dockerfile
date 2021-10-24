FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JsonDemoTwo/JsonDemoTwo.csproj", "JsonDemoTwo/"]
RUN dotnet restore "JsonDemoTwo/JsonDemoTwo.csproj"
COPY . .
WORKDIR "/src/JsonDemoTwo"
RUN dotnet build "JsonDemoTwo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JsonDemoTwo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JsonDemoTwo.dll"]
