FROM public.ecr.aws/lambda/dotnet:5.0 AS base 
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build 

WORKDIR /src 
ENV ASPNETCORE_ENVIRONMENT=Development 

RUN apt-get update && apt-get install -y sqlite3 libsqlite3-mod-spatialite 

COPY . . 
RUN dotnet restore 

WORKDIR "/src/HomeDev.WebApi.Sqlite" 
RUN dotnet build "HomeDev.WebApi.Sqlite.csproj" --configuration Release --output /app/build 

FROM build AS publish 
RUN dotnet publish "HomeDev.WebApi.Sqlite.csproj" \ 
            --configuration Release \  
            --runtime linux-x64 \ 
            --self-contained false \  
            --output /app/publish \ 
            -p:PublishReadyToRun=true   

FROM base AS final 
WORKDIR /var/task 
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "HomeDev.WebApi.Sqlite.dll"]

# docker build -t img-homedev-webapi-sqlite .
# docker run --name homedev-webapi-sqlite -dp 5000:80 img-homedev-webapi-sqlite