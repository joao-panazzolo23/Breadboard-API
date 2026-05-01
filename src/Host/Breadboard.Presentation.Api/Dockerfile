FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# copia TUDO da solution
COPY . .

# restore da solution ou projeto principal
RUN dotnet restore src/Host/Breadboard.Presentation.Api/Breadboard.Presentation.Api.csproj

# publish
RUN dotnet publish \
    src/Host/Breadboard.Presentation.Api/Breadboard.Presentation.Api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false
 
# runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Breadboard.Presentation.Api.dll"]