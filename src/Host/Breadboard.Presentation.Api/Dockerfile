FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# copies all projects
COPY . . 
#in production-grade projects, we usually declare all projects, one by one
#just to keep all cache 
#COPY src/Modules/Expenses/*.csproj src/Modules/Expenses/ #just like that

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

USER app
EXPOSE 8080

#ENV ASPNETCORE_URLS=http://+:8080

#modern way
ENV ASPNETCORE_HTTP_PORTS=8080 

ENTRYPOINT ["dotnet", "Breadboard.Presentation.Api.dll"]