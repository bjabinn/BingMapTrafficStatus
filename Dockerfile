FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY BingMapCore2_1.csproj ./
RUN dotnet restore BingMapCore2_1.csproj
COPY . .
WORKDIR /src/
RUN dotnet build BingMapCore2_1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BingMapCore2_1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BingMapCore2_1.dll"]
