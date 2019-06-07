FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["DockerForNgnix/DockerForNgnix.csproj", "DockerForNgnix/"]
RUN dotnet restore "DockerForNgnix/DockerForNgnix.csproj"
COPY . .
WORKDIR "/src/DockerForNgnix"
RUN dotnet build "DockerForNgnix.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerForNgnix.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerForNgnix.dll"]